using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayMax
{
	public class Tests
	{
		private static readonly object[] providerFindSmallestTransaction =
		{
			new int[] { -1000, -100, -10, -1 },
			new int[] { -1000 },
			new int[] { -1000, -100, -10, -1, -1 },
			new int[] { -1000, -100, -10, -1, -1, 0 },
			new int[] { int.MinValue}
		};

		[Test(Description = "Finding smallest transaction")]
		[TestCaseSource(nameof(providerFindSmallestTransaction))]
		public void FindSmallestTransactionTest(int[] array)
		{
			var actual = ArrayMax.FindSmallestTransaction(array);
			Array.Sort(array);
			var expected = array[array.Length - 1];
			Assert.AreEqual(expected, actual);
		}


		private static readonly object[] providerFindBestStudentMistakes =
		{
			new int[] { 9, 4, 1, 8, 7, 13, 6, 5 },
			new int[] { 1000 },
			new int[] { 9, 4, 1, 8, 7, 13, 6, 5, 1, 1, 1, 1, 1 },
			new int[] { 9, 4, 1, 8, 7, 13, 6, 5, 0 },
			new int[] { int.MaxValue}
		};

		[Test(Description = "Finding best student")]
		[TestCaseSource(nameof(providerFindBestStudentMistakes))]
		public void FindBestStudentMistakesTest(int[] array)
		{
			var actual = ArrayMax.FindBestStudentMistakes(array);
			Array.Sort(array);
			var expected = array[0];
			Assert.AreEqual(expected, actual);
		}

		private static readonly object[] providerFindAverageTime =
		{
			new int[] { 9999 },
			new int[] { 9, 4, 1, 8, 7, 9, 4, 1, 8, 7, 8, 7, 18, 3, 13, 6, 5 },
			new int[] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }
		};

		[Test(Description = "Finding average time")]
		[TestCaseSource(nameof(providerFindAverageTime))]
		public void FindAverageTimeTest(int[] array)
		{
			var actual = ArrayMax.FindAverageTime(array);
			var expected = array.Average();
			Assert.AreEqual(expected, actual);
		}


		private static readonly object[][] providerFindMostProfitableClient =
		{
			new int[][]
			{
				new int [] {11, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {12, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {13, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {14, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {15, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {16, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {17, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {18, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {19, 2, 3, 4, 5, 6, 7, 8, 9, 0},
				new int [] {10, 2, 3, 4, 5, 6, 7, 8, 9, 0}
			},

			new int[][]
			{
				new int [] {1, int.MaxValue, int.MinValue},
				new int [] {1, 2, 3},
			},

			new int[][]
			{
				new int [] {1, 9999, -10},
				new int [] {1},
			},

			new int[][]
			{
				new int [] {95, 67, 13, 55, 44, 11, 10},
				new int [] {7, 190, 4, 44, 11, 1, 99},
				new int [] {0, 5, -1, 500, 14, 90, 1},
			}
		};

		[Test(Description = "Finding most profitable client")]
		[TestCaseSource(nameof(providerFindMostProfitableClient))]
		public void FindMostProfitableClientTest(int[][] arrays)
		{
			var actual = ArrayMax.FindMostProfitableClient(arrays);
			var temp = new Dictionary<int, double>();
			for (int i = 0; i < arrays.Length; i++)
			{
				temp.Add(i, arrays[i].Average());
			}
			var expected = temp.First(p=>p.Value == temp.Max(p=>p.Value)).Key;
			Assert.AreEqual(expected, actual);
		}
	}
}