
using System;

namespace InsertionPlace
{
	public class UrbanDictionary
	{
		private static string[] newRussianDictionary = new string[] { "Контент", "Лутер", "Тренд", "Фиксер", "Фэшн", "Хипстер" };

		// Как и в любом словаре, у вас слова идут строго порядку.
		// Напишите функцию которая будет вставлять в словарь новые слова,

		public void InsertNewWord(string word)
		{
			if (string.IsNullOrWhiteSpace(word))
				throw new ArgumentException(nameof(word));

			int length = newRussianDictionary.Length;

			int left = 0;
			int right = length - 1;

			while (left < right)
			{
				int middle = (right + left) / 2;
				int difference = word.ToLower().CompareTo(newRussianDictionary[middle].ToLower());

				if (difference < 0)
					right = middle - 1;

				else if (difference > 0)
					left = middle + 1;
				else
					throw new InvalidOperationException("Слово уже есть в словаре.");
			}

			Array.Resize(ref newRussianDictionary, length + 1);

			for (int i = length - 1; i > left; --i)
				newRussianDictionary[i] = newRussianDictionary[i - 1];

			newRussianDictionary[left] = word;
		}
	}
}
