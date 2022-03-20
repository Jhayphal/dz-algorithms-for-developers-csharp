using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class CountingSort
	{
		// реализовать метод сортировки подсчетом
		public static void Sort(int[] array, int maxValue)
		{
			if (maxValue < 1)
				return;

			int[] scores = new int[maxValue];

			for (int i = 0; i < array.Length; ++i)
				scores[array[i]] += 1;

			int currentIndex = 0;

			for (int i = 0; i < maxValue; ++i)
			{
				int count = scores[i];

				while (count-- > 0)
					array[currentIndex++] = i;
			}
		}
	}
}
