using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
	public class WorkPlannerTest
	{
		public class WorkRatesTest
		{
			public readonly int[] Prices;
			public readonly int K;
			public readonly int Expected;

			public WorkRatesTest(int k, int[] prices, int expected)
			{
				K = k;
				Prices = prices;
				Expected = expected;
			}
		}

		public static readonly object[] WorkRates =
		{
			new WorkRatesTest(2, new int[] { 334934939, 1234122, 657657 }, 336169061),
			new WorkRatesTest(5, new int[] { }, 0),
			new WorkRatesTest(1, new int[] { 1 }, 1),
			new WorkRatesTest(4, new int[] { 1, 1, 3 }, 5),
			new WorkRatesTest(3, new int[] { 100, 50, 30, 20, 10 }, 180),
			new WorkRatesTest(5, new int[] { 1, 1, 1, 1, 1 }, 5),
			new WorkRatesTest(0, new int[] { 1 }, 0)
		};

		[Test(Description = "Maximum Income")]
		[TestCaseSource(nameof(WorkRates))]
		public void MaximumIncome(WorkRatesTest workRatesTest)
		{
			var userSum = WorkPlanner.FindMaximumIncome(workRatesTest.Prices, workRatesTest.K);
			Assert.AreEqual(workRatesTest.Expected, userSum);
		}

		public static readonly object[] Times =
		{
			new object[] { new int[][] { new[] { 1, 2 },    new[] { 2, 3 } }, 1},
			new object[] { new int[][] { new[] { 1, 24 },   new[] { 5, 10 }, new[] { 1, 20 } }, 3 },
			new object[] { new int[][] { new[] { 7, 9 },    new[] { 8, 10 }, new [] { 9, 10 } }, 2 },
			new object[] { new int[][] { new[] { 7, 9 },    new[] { 8, 10 } }, 2 },
			new object[] { new int[][] { new[] { 7, 9 } }, 1 },
			new object[] { new int[][] { }, 0 }
		};


		[Test(Description = "Find Managers")]
		[TestCaseSource(nameof(Times))]
		public void FindMinimumManagersTest(int[][] array, int result)
		{
			Assert.AreEqual(result, WorkPlanner.FindMinimumManagers(array));
		}

		public class TruckTest
		{
			public readonly int TruckCapacity;
			public readonly int[][] Goods;
			public readonly double Expected;

			public TruckTest(int truckCapacity, int[][] goods, double expected)
			{
				TruckCapacity = truckCapacity;
				Goods = goods;
				Expected = expected;
			}
		}

		public static readonly object[] TruckGoods =
		{
			new TruckTest(1000, new int[][]
				{
					new int[] {86, 482},
					new int[] {911, 306},
					new int[] {77, 319},
					new int[] {663, 382},
					new int[] {58, 408},
					new int[] {918, 348},
					new int[] {395, 372},
					new int[] {757, 384},
					new int[] {126, 317},
					new int[] {325, 931}
				},
				2511.08),
			new TruckTest(1000, new int[][] { new [] { 500, 30 } }, 500d),
			new TruckTest(1, new int[][] {  new [] { 500, 30 } }, 16.6),
			new TruckTest(15, new int[][] {  new [] { 500, 30 } }, 250d),
			new TruckTest(0, new int[][] {  new [] { 500, 30 } }, 0),
			new TruckTest(1000, new int[][] { }, 0)
		};



		[Test(Description = "Fill truck")]
		[TestCaseSource(nameof(TruckGoods))]
		public void LoadTruckTest(TruckTest truckTest)
		{
			Assert.AreEqual(truckTest.Expected, WorkPlanner.LoadTruck(truckTest.TruckCapacity, truckTest.Goods), 0.1d);
		}
	}
}
