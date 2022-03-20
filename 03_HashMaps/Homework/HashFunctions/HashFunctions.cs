using NUnit.Framework;
using System;
using System.Linq;

namespace HashFunctions
{
	public class HashFunctions
	{
		public int HashString(string input)
		{
			if (input == null)
				return -1;

			int hash = 0;

			foreach (char c in input)
				hash += c;

			return hash;
		}

		public int HashInt(int input)
		{
			if (input == 0)
				return 0;

			bool negative = input < 0;

			if (negative)
				input = -input;

			const int Ten = 10;

			int hash = 1;

			while (input > 9)
			{
				hash *= input % Ten;
				input /= Ten;
			}

			hash += input;

			if (negative)
				hash = -hash;

			return hash;
		}

		public class Student
		{
			public int Age { get; set; }
			public string Name { get; set; }
		}

		public int HashStudent(Student input)
		{
			if (input == null)
				return -1;

			return HashInt(input.Age) ^ HashString(input.Name);
		}

		[Test]
		public void HashStringTest()
		{
			string[] values = new string[] { null, string.Empty, "1", "2", "a", "A", "Lol", "LOL" };
			var hashedCount = GetDistinctCount(values, HashString);

			Assert.AreEqual(values.Length, hashedCount);
		}

		[Test]
		public void HashIntTest()
		{
			int[] values = new int[] { -1000, -999, 0, 1, 9, 1000, 123456789 };
			var hashedCount = GetDistinctCount(values, HashInt);

			Assert.AreEqual(values.Length, hashedCount);
		}

		[Test]
		public void HashStudentTest()
		{
			Student[] values = new Student[] 
			{
				null,
				new Student{ Age = 12, Name = null },
				new Student{ Age = 12, Name = string.Empty },
				new Student{ Age = 12, Name = "Tommy" },
				new Student{ Age = 11, Name = "Tommy" },
				new Student{ Age = 12, Name = "TOMMY" },
				new Student{ Age = 12, Name = "T" },
			};

			var hashedCount = GetDistinctCount(values, HashStudent);

			Assert.AreEqual(values.Length, hashedCount);
		}

		private static int GetDistinctCount<T>(T[] values, Func<T, int> hashFunction)
		{
			return values
				.Select(x => hashFunction(x))
				.GroupBy(x => x)
				.Count();
		}
	}
}