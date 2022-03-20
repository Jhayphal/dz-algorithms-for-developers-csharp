using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
	public class WorkPlanner
	{
		public static int FindMaximumIncome(int[] workRates, int k)
		{
			if (k < 1)
				return 0;

			if ((workRates?.Length ?? 0) == 0)
				return 0;

			Array.Sort(workRates);

			k = Math.Min(k, workRates.Length);
			
			int result = 0;

			while(k > 0)
				result += workRates[workRates.Length - k--];

			return result;
		}

		public static int FindMinimumManagers(int[][] rawIntervals)
		{
			if ((rawIntervals?.Length ?? 0) == 0)
				return 0;

			int result = 1;

			var query = rawIntervals
				.OrderBy(x => x[1] + x[0])
				.ToArray();

			for (int i = 0; i < query.Length; ++i)
				for (int j = i + 1; j < query.Length; ++j)
					if (query[i] != null && query[j] != null)
					{
						if (query[j][0] < query[i][1])
							++result;

						query[j] = null;
					}

			return result;
		}

		private const int SummaryCount = 1;
		private const int SummaryCost = 0;

		public static double LoadTruck(int truckCapacity, int[][] goods)
		{
			if (truckCapacity == 0)
				return 0d;

			if ((goods?.Length ?? 0) == 0)
				return 0d;

			var query = goods
				.OrderByDescending(x => x[SummaryCost] / (double)x[SummaryCount])
				.ToArray();

			double result = 0d;

			int currentItemIndex = 0;

			while(truckCapacity > 0 && currentItemIndex < query.Length)
			{
				int summaryCount = query[currentItemIndex][SummaryCount];
				int summaryCost = query[currentItemIndex][SummaryCost];

				double cost = summaryCost / (double)summaryCount;

				int count = Math.Min(truckCapacity, summaryCount);

				result += count * cost;

				truckCapacity -= count;

				++currentItemIndex;
			}

			return result;
		}
	}
}
