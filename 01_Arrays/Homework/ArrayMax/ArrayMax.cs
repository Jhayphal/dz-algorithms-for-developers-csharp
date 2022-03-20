using System;

namespace ArrayMax
{
	public class ArrayMax
	{
		// Task #1
		public static int FindSmallestTransaction(int[] transactions)
		{
			int max = int.MinValue;

			foreach (int x in transactions)
				if (max < x)
					max = x;

			return max;
		}

		// Task #2
		public static int FindBestStudentMistakes(int[] students)
		{
			int min = int.MaxValue;

			foreach (int x in students)
				if (min > x)
					min = x;

			return min;
		}

		// Task #3
		public static double FindAverageTime(int[] times)
		{
			double sum = 0;

			foreach (var x in times)
				sum += x;

			return sum / times.Length;
		}

		// Task #4
		public static int FindMostProfitableClient(int[][] income)
		{
			int mostProfitableClientId = 0;
			int currentClientId = 0;
			double maxAvarage = double.MinValue;

			foreach (var x in income)
			{
				var avg = FindAverageTime(x);

				if (avg > maxAvarage)
				{
					maxAvarage = avg;
					mostProfitableClientId = currentClientId;
				}

				++currentClientId;
			}

			return mostProfitableClientId;
		}
	}
}
