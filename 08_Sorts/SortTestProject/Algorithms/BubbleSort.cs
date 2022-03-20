using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject.Algorithms
{
	public class BubbleSort
	{
		public static void Sort(Item[] items)
		{
			for (int j = 1; j < items.Length; ++j)
				for (int i = 0; i < items.Length - j; ++i)
					if (items[i].CompareTo(items[i + 1]) > 0)
						Swap(items, i, i + 1);
		}

		private static void Swap(Item[] array, int indexA, int indexB)
		{
			var temp = array[indexA];
			array[indexA] = array[indexB];
			array[indexB] = temp;
		}
	}
}
