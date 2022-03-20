using NUnit.Framework;
using SortTestProject.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject
{
	public class QuickSortTest
	{
		private static object[] ProvideArraysForSort =
		{
			TestData.CreateArguments(new int[] { 1, 2, 3 }, 4),
			TestData.CreateArguments(new int[] { 3, 2, 1 }, 4),
			TestData.CreateArguments(new int[] { 0, 0, 1, 0, 0 }, 15),
			TestData.CreateArguments(new int[] { -1, -2, 0, 1, 2 }, 11),
			TestData.CreateArguments(new int[] { 0 }, 0),
			TestData.CreateArguments(new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0 }, 36),
			TestData.CreateArguments(new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0, -10, -20, -30, -40 }, 48)
		};

		[Test(Description = "Количество сравнений элементов массива")]
		[TestCaseSource(nameof(ProvideArraysForSort))]
		public void SortAndTestEqualsAmount(TestData testData)
		{
			Item[] actual = testData.testArray;
			Item.ClearAmountCompareTo();
			QuickSortAlgorithms.Sort(actual);
			long compareToAmountInActual = Item.GetAmountCompareTo();
			Assert.AreEqual(testData.compareToAmount, compareToAmountInActual, "Количество проверок элементов превышает достаточное для сортировки");
		}


		[Test(Description = "Массив отсортирован")]
		[TestCaseSource(nameof(ProvideArraysForSort))]
		public void Sort(TestData testData)
		{
			Item[] actual = testData.testArray;
			QuickSortAlgorithms.Sort(actual);
			Assert.AreEqual(testData.expected, actual, testData.ReadableDifferenceBetweenArrays());
		}
	}
}
