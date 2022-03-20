using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
	public class BinarySearchTest
	{
		public class DatingUser
		{
			public int Iq;
			public string Name;

			public override string ToString()
			{
				return $"IQ: {Iq}; Name: {Name}";
			}
		}

		public static bool DoIKnowThisLanguage(string[] languagesList, string language)
		{
			if (languagesList == null
				|| languagesList.Length == 0)
				return false;

			if (string.IsNullOrWhiteSpace(language))
				throw new ArgumentException(nameof(language));

			language = language.ToLower();

			int left = 0;
			int right = languagesList.Length - 1;

			while(left <= right)
			{
				int middle = (right + left) / 2;
				int difference = language.CompareTo(languagesList[middle]?.ToLower());
				
				if (difference < 0)
					right = middle - 1;

				else if (difference > 0)
					left = middle + 1;
				else
					return true;
			}

			return false;
		}

		public static List<string> FindUsers(DatingUser[] usersSortedByIQ, int lowerIQBound, int professorIQ)
		{
			if (professorIQ < lowerIQBound)
				throw new ArgumentException();

			var result = new List<string>();

			if ((usersSortedByIQ?.Length ?? 0) == 0)
				return result;

			int left = 0;
			int right = usersSortedByIQ.Length - 1;

			bool found = false;

			while (left <= right)
			{
				int middle = (right + left) / 2;
				var current = usersSortedByIQ[middle];

				if (current.Iq > professorIQ)
					right = middle - 1;

				else if (current.Iq < lowerIQBound)
					left = middle + 1;

				else // ищем левую границу
				{
					found = true;

					if (right == left)
						break;

					right -= 2;
				}
			}

			if (!found)
				return result;

			int leftSide = left;

			left = 0;
			right = usersSortedByIQ.Length - 1;

			while (left < right)
			{
				int middle = (right + left) / 2;
				var current = usersSortedByIQ[middle];

				if (current.Iq > professorIQ)
					right = middle - 1;

				else // ищем правую границу
					left = middle + 1;
			}

			int rightSide = right;

			for (int i = leftSide; i <= rightSide; ++i)
				result.Add(usersSortedByIQ[i].Name);

			return result;
		}

		public static int FindPhoneNumber(long[] sortedPhoneNumbers, long search)
		{
			if (sortedPhoneNumbers == null
				|| sortedPhoneNumbers.Length == 0)
				return -1;

			long sortDirection = 0;

			for (int i = 1; i < sortedPhoneNumbers.Length; ++i)
				if ((sortDirection = sortedPhoneNumbers[i] - sortedPhoneNumbers[i - 1]) != 0)
					break;

			if (sortDirection == 0) // значит все элементы в массиве одинаковые
				if (sortedPhoneNumbers[0] == search)
					return 0;
				else
					return -1;

			int left = 0;
			int right = sortedPhoneNumbers.Length - 1;

			while (left <= right)
			{
				int middle = (right + left) / 2;
				int difference = search.CompareTo(sortedPhoneNumbers[middle]);
				
				if (sortDirection < 0)
					difference *= -1;

				if (difference < 0)
					right = middle - 1;

				else if (difference > 0)
					left = middle + 1;
				else
					return middle;
			}

			return -1;
		}

		[Test]
		public void Test1()
		{
			string[] languagesList = new string[]
			{
				"ADA",
				"CAVO",
				"CLIPPER",
				"JAVA",
				"JAVASCRIPT",
				"X#"
			};

			//Можно использовать для локального тестирования кода.
			Assert.AreEqual(true, DoIKnowThisLanguage(languagesList, "CAVO"));

			Assert.AreEqual(false, DoIKnowThisLanguage(languagesList, "C#"));

			Assert.AreEqual(true, DoIKnowThisLanguage(languagesList, "ADA"));

			Assert.AreEqual(true, DoIKnowThisLanguage(languagesList, "X#"));

			Assert.AreEqual(true, DoIKnowThisLanguage(languagesList, "Java"));



			DatingUser[] usersSortedByIQ = new
				DatingUser[]
			{
				new DatingUser { Iq = -12, Name = "Никита" },
				new DatingUser { Iq = -12, Name = "Стас"},
				new DatingUser { Iq = -1, Name = "Жека Турбо"},
				new DatingUser { Iq = 2, Name = "Дюша Метелкин" },
				new DatingUser { Iq = 78, Name = "Виктория" },
				new DatingUser { Iq = 113, Name = "Евгения" },
				new DatingUser { Iq = 157, Name = "Скарлет Йохансон" },
				new DatingUser { Iq = 160, Name = "Дочь Эйнштейна" }
			};

			var users = FindUsers(usersSortedByIQ, 0, 200);
			Assert.AreEqual(5, users.Count);

			users = FindUsers(usersSortedByIQ, 50, 100);
			Assert.AreEqual(1, users.Count);

			users = FindUsers(usersSortedByIQ, 113, 113);
			Assert.AreEqual(1, users.Count);

			users = FindUsers(usersSortedByIQ, 50, 60);
			Assert.AreEqual(0, users.Count);

			users = FindUsers(usersSortedByIQ, -50, 0);
			Assert.AreEqual(3, users.Count);

			users = FindUsers(usersSortedByIQ, 150, 160);
			Assert.AreEqual(2, users.Count);

			users = FindUsers(usersSortedByIQ, -1000, +1000);
			Assert.AreEqual(usersSortedByIQ.Length, users.Count);



			long[] phones = new long[] { -1, 0, 1, 2, 4, 5, 6, 8, 9, 10 };
			long[] phonesDescend = new long[] { 10, 9, 7, 6, 5, 2, 0, -1 };

			Assert.AreEqual(6, FindPhoneNumber(phones, 6));
			Assert.AreEqual(-1, FindPhoneNumber(phones, 7));
			Assert.AreEqual(0, FindPhoneNumber(phones, -1));
			Assert.AreEqual(9, FindPhoneNumber(phones, 10));

			Assert.AreEqual(3, FindPhoneNumber(phonesDescend, 6));
			Assert.AreEqual(0, FindPhoneNumber(phonesDescend, 10));
			Assert.AreEqual(-1, FindPhoneNumber(phonesDescend, 8));
			Assert.AreEqual(7, FindPhoneNumber(phonesDescend, -1));
		}
	}
}