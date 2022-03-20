using NUnit.Framework;
using SortTestProject.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject
{
	public class MergeSortTest
	{
		private static object[] ProvideArraysForSort =
		{
			TestData.CreateArguments(new int[] { 1, 2, 3 }, 2),
			TestData.CreateArguments(new int[] { 3, 2, 1 }, 3),
			TestData.CreateArguments(new int[] { 0, 0, 1, 0, 0 }, 8),
			TestData.CreateArguments(new int[] { -1, -2, 0, 1, 2 }, 5),
			TestData.CreateArguments(new int[] { 0 }, 0),
			TestData.CreateArguments(new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0 }, 22),
			TestData.CreateArguments(new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 0, -10, -20, -30, -40 }, 31)
		};

		[Test(Description = "Количество сравнений элементов массива")]
		[TestCaseSource(nameof(ProvideArraysForSort))]
		public void SortAndTestEqualsAmount(TestData testData)
		{
			Item[] actual = testData.testArray;
			Item.ClearAmountCompareTo();
			MergeSort.Sort(actual);
			long compareToAmountInActual = Item.GetAmountCompareTo();
			Assert.AreEqual(testData.compareToAmount, compareToAmountInActual, "Количество проверок элементов превышает достаточное для сортировки");
		}


		[Test(Description = "Массив отсортирован")]
		[TestCaseSource(nameof(ProvideArraysForSort))]
		public void Sort(TestData testData)
		{
			Item[] actual = testData.testArray;
			MergeSort.Sort(actual);
			Assert.AreEqual(testData.expected, actual, testData.ReadableDifferenceBetweenArrays());
		}
	}
}
