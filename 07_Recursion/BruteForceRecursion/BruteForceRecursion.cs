using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceRecursion
{
	public class BruteForceRecursion
	{
		// Task #1
		public static List<List<int>> OrderOfReleaseFeatures(int[] numbersOfFeatures)
		{
			var result = new List<List<int>>();

			if (numbersOfFeatures.Length < 2)
			{
				if (numbersOfFeatures.Length == 1)
					result.Add(new List<int> 
					{ 
						numbersOfFeatures[0] 
					});

				return result;
			}

			var tempData = new int[numbersOfFeatures.Length];
			var userIndexes = new int[numbersOfFeatures.Length];
			
			for (int i = 0; i < numbersOfFeatures.Length; ++i)
				userIndexes[i] = -1;

			generateOrders(numbersOfFeatures, result, userIndexes, tempData);

			return result;
		}

		private static void generateOrders
		(
			int[] numbersOfFeatures, 
			List<List<int>> result, 
			int[] usedIndexes,
			int[] tempData, 
			int level = 0
		)
		{
			if (level >= numbersOfFeatures.Length) {
				result.Add(new List<int>(tempData));

				return;
			}

			for (int i = 0; i < numbersOfFeatures.Length; ++i)
			{
				bool exists = false;

				for (int j = 0; j < usedIndexes.Length; ++j)
					if (exists = (usedIndexes[j] == i))
						break;

				if (exists)
					continue;

				usedIndexes[level] = i;
				tempData[level] = numbersOfFeatures[i];

				generateOrders(
					numbersOfFeatures, 
					result, 
					usedIndexes, 
					tempData, 
					level + 1);

				usedIndexes[level] = -1;
			}
		}

		// Task #2
		public static bool CheckPowersOfThree(int number)
		{
			int upperBorder = (int)Math.Pow(number, 1d / 3d);

			for (int i = 0; i <= upperBorder; ++i)
				if (checkPowersOfThreeSum(number, i, upperBorder, 0))
					return true;

			return false;
		}

		private static bool checkPowersOfThreeSum(int number, int startFrom, int upTo, int sum)
		{
			sum += (int)Math.Pow(3D, startFrom);

			if (sum == number)
				return true;

			for (int i = startFrom + 1; i <= upTo; ++i)
				if (checkPowersOfThreeSum(number, i, upTo, sum))
					return true;

			return false;
		}

		// Task #3
		public static List<string> PossibleMessages(string digits)
		{
			var result = new List<string>();

			if (string.IsNullOrWhiteSpace(digits))
				return result;

			var data = new char[digits.Length];

			generate(result, digits, 0, data);

			return result;
		}

		private static void generate(List<string> result, string digits, int current, char[] data)
		{
			if (current == digits.Length)
			{
				result.Add(new string(data));

				return;
			}

			int index = int.Parse(digits[current].ToString());
			var various = DigitToPossibleLetters[index];

			foreach(var letter in various)
			{
				data[current] = letter;

				generate(result, digits, current + 1, data);
			}
		}

		// This can be a hashtable, any structure to map 'number' to 'letters' it can manifest as
		private static readonly List<string> DigitToPossibleLetters = new()
		{
			"",     // 0
			"",     // 1
			"abc",  // 2
			"def",  // 3
			"ghi",  // 4
			"jkl",  // 5
			"mno",  // 6
			"pqrs", // 7
			"tuv",  // 8
			"wxyz"  // 9
		};
	}
}
