using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Heap
{
	public class HeapTest
	{
		private static readonly object[] arrays =
		{
			new int[] { 1, 2, -1 },
			new int[] { },
			new int[] { 1 },
			Enumerable.Range(int.MinValue, 100).ToArray()
		};

		private static readonly object[] trucks =
		{
			new int[] { 1, 1 },
			new int[] { 100, 5 },
			new int[] { 1000, 5 },
			new int[] { 10, 500 },
			new int[] { 10_000, 500 }
		};


		[Test(Description = "Heap build")]
		[TestCaseSource(nameof(arrays))]
		public void BuildHeapTest(int[] arr)
		{
			Heap<int>.BuildHeapFromArray(arr);
			Assert.IsTrue(IsHeap(arr, arr.Length - 1));
		}

		[Test(Description = "Find trucks")]
		[TestCaseSource(nameof(trucks))]
		public void kClosestTrucksTest(int[] arr)
		{
			var rand = new Random();
			var lst = Enumerable.Range(int.MinValue, arr[0]).Select(k => new TruckCoordinate(rand.Next(), rand.Next())).ToList();
			var ans = Heap<TruckCoordinate>.KClosestTrucks(lst, arr[1]);
			ans.Sort();
			var test = ClosestTrucks(lst, arr[1]);
			test.Sort();
			Assert.AreEqual(ans.Count, test.Count);
			AssertEqualsArray(ans, test);
		}

		[Test(Description = "Unloading trucks")]
		public void UnloadingTruckTest()
		{
			var rand = new Random();
			var n = rand.Next(0, 50);

			var lst = Enumerable.Range(1, rand.Next(0, 1000)).Select(p => rand.Next(0, 1000)).ToArray();
			var ans = Heap<long>.UnloadingTruck(n, lst);
			var test = HandleTrucks(n, lst);
			Assert.AreEqual(ans.Count, test.Count);
			AssertEqualsArray(ans, test);
		}

		public static List<long> HandleTrucks(int n, int[] tasks)
		{
			PriorityQueue<TruckTime, TruckTime> priorityQueue = new PriorityQueue<TruckTime, TruckTime>(new TruckTimeComparer());
			for (int i = 0; i < n; i++)
			{
				var trucTime = new TruckTime();
				priorityQueue.Enqueue(trucTime, trucTime);
			}
			var records = new List<long>();

			foreach (var task in tasks)
			{
				var truckTime = priorityQueue.Dequeue();
				records.Add(truckTime.time);
				truckTime.time += task;
				priorityQueue.Enqueue(truckTime, truckTime);
			}
			return records;
		}

		private static void AssertEqualsArray(IList expected, IList actual)
		{
			Assert.AreEqual(expected, actual,
				$"Extended array {Environment.NewLine}{string.Join(Environment.NewLine, expected)}" +
				$"{Environment.NewLine}  Actual array{Environment.NewLine}{string.Join(Environment.NewLine, actual)}");
		}
		private static bool IsHeap(int[] arr, int n)
		{
			for (var i = 0; i <= (n - 2) / 2; i++)
			{
				if (arr[2 * i + 1] > arr[i])
				{
					return false;
				}
				if (2 * i + 2 < n && arr[2 * i + 2] > arr[i])
				{
					return false;
				}
			}
			return true;
		}

		public List<TruckCoordinate> ClosestTrucks(List<TruckCoordinate> points, int k)
		{
			PriorityQueue<TruckCoordinate, TruckCoordinate> priorityQueue = new PriorityQueue<TruckCoordinate, TruckCoordinate>(new TruckCoordinateComparer());

			foreach (var item in points)
			{
				priorityQueue.Enqueue(item, item);
			}


			List<TruckCoordinate> res = new List<TruckCoordinate>();

			for (var l = 0; priorityQueue.Count > 0 && l < k; l++)
			{
				res.Add(priorityQueue.Dequeue());
			}
			return res;
		}

		public class TruckCoordinateComparer : IComparer<TruckCoordinate>
		{
			public int Compare(TruckCoordinate o1, TruckCoordinate o2)
			{
				double dist1 = Math.Sqrt(Math.Pow((o1.X), 2) + Math.Pow((o1.Y), 2));
				double dist2 = Math.Sqrt(Math.Pow((o2.X), 2) + Math.Pow((o2.Y), 2));
				return dist1.CompareTo(dist2);
			}
		}

		public class TruckTimeComparer : IComparer<TruckTime>
		{
			public int Compare(TruckTime o1, TruckTime o2)
			{
				if (o1.time == o2.time)
					return o1.id - o2.id;
				return o1.time.CompareTo(o2.time);

			}
		}

		public class TruckTime
		{
			public int id;
			public long time = 0;
			private static int i = 0;

			public TruckTime()
			{
				id = i++;
			}
		}
	}
}