using NUnit.Framework;
using SortAlgorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SortTest
{
	public class Tests
	{
		private static void AssertEqualsArray(IList expected, IList actual)
		{
			Assert.AreEqual(expected, actual,
				$"Extended array {Environment.NewLine}{string.Join(Environment.NewLine, expected)}" +
				$"{Environment.NewLine}  Actual array{Environment.NewLine}{string.Join(Environment.NewLine, actual)}");
		}



		private static readonly int[][] BubbleSortData = new int[][]
		{
					new int[] { 334934939, 1234122, 657657 },
					new int[] { },
					new int[] { 1 }
		};


		[Test(Description = "Bubble sort")]
		[TestCaseSource(nameof(BubbleSortData))]
		public void BubbleSortTest(int[] array)
		{
			array.ToString();
			var userArray = new int[array.Length];
			Array.Copy(array, userArray, array.Length);
			Array.Sort(array);
			BubbleSort.Sort(userArray);
			AssertEqualsArray(array, userArray);
		}


		[Test(Description = "Bubble sort big Random array")]
		public void BubbleSortTestBigRandom()
		{
			var random = new Random();
			var array = Enumerable.Range(0, 10000).Select(p => random.Next()).ToArray();
			var userArray = new int[array.Length];
			Array.Copy(array, userArray, array.Length);
			Array.Sort(array);
			BubbleSort.Sort(userArray);
			AssertEqualsArray(array, userArray);
		}

		private static readonly object[] SelectionSortData = new int[][]
		{

					new int[] { 3, 2, 1 },
					new int[] { },
					new int[] { 1 },
					Enumerable.Range(1, 100).OrderByDescending(p => p).ToArray()
		};
		[Test(Description = "Selection sort")]
		[TestCaseSource(nameof(SelectionSortData))]
		public void SelectionSortTest(int[] array)
		{
			var customArray = new CustomArray(array);
			SelectionSort.sort(customArray);
			Assert.AreEqual(array.Length * 2, customArray.GetIteration());
		}


		[Test(Description = "Insertion sort")]
		public void InsertionSortTest()
		{
			var listOfAnimals = new List<IAnimal> {
					new ZooAnimal(100, "Zebra Fibi"),
					new ZooAnimal(505, "Lion Gunter"),
					new ZooAnimal(5, "Meerkat Joe"),
					new ZooAnimal(100, "Zebra Monika"),
					new ZooAnimal(50, "Deer Ross"),
					new ZooAnimal(5, "Meerkat Chandler")
			};
			var expectedArray = listOfAnimals.ToArray();
			var userArray = listOfAnimals.ToArray();

			InsertionSort.Sort(userArray);
			ZooAnimal.Sort(expectedArray);
			AssertEqualsArray(expectedArray, userArray);
		}


		[Test(Description = "Counting sort")]
		public void CountingSortTest()
		{
			var array = Enumerable.Range(0, 100000).Select(p => new Random().Next(1, 100)).ToArray();
			var userArray = new int[array.Length];
			Array.Copy(array, userArray, array.Length);

			var stopWatch = new Stopwatch();
			stopWatch.Start();
			Array.Sort(array);
			stopWatch.Stop();
			var quickSort = stopWatch.ElapsedTicks;

			stopWatch.Reset();
			stopWatch.Start();
			CountingSort.Sort(userArray, 100);
			stopWatch.Stop();
			var countingSort = stopWatch.ElapsedTicks;

			Assert.True((quickSort / countingSort) > 2);
		}
	}
}