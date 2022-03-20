using System;
using System.Collections.Generic;

namespace ArrayUnique
{
	public class ArrayUnique
	{
		public static List<char> LettersLearnedToday(string word)
		{
			// самый простой способ, но без алгоритмов
			//HashSet<char> learnedLetters = new HashSet<char>(word);
			//return new List<char>(learnedLetters);

			List<char> result = new List<char>();
			
			foreach(var x in word)
			{
				bool found = false;

				foreach (var y in result)
					if (found = y == x)
						break;

				if (!found)
					result.Add(x);
			}

			return result;
		}

		public static int AvoidJailDueToTaxFraud(int[][] report)
		{
			List<int> cache = new List<int>();

			foreach (var row in report)
				foreach (var cell in row)
					if (cache.Contains(cell))
						return cell;
					else
						cache.Add(cell);

			return -1;
		}
	}
}
