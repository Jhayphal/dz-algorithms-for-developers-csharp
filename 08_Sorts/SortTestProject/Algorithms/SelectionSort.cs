using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject.Algorithms
{
	public class SelectionSort
	{
		public static void Sort(Item[] items)
		{
			int count = items.Length;

			for (int i = 0; i < count; ++i)
			{
				var min = items[i];
				int minIndex = i;

				for (int j = i + 1; j < count; ++j)
				{
					var current = items[j];

					if (current.CompareTo(min) < 0)
					{
						min = current;
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					var temp = items[i];
					items[i] = min;
					items[minIndex] = temp;
				}
			}
		}
	}
}
