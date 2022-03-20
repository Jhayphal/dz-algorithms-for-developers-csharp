using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject.Algorithms
{
	public class InsertionSort
	{
		public static void Sort(Item[] items)
		{
			for (int i = 1; i < items.Length; ++i)
			{
				int left = i - 1;
				var current = items[i];

				if (current.CompareTo(items[left]) >= 0)
					continue;

				while (left > 0 && current.CompareTo(items[--left]) < 0) ;

				if (current.CompareTo(items[left]) >= 0)
					++left;

				var value = items[i];

				for (int j = i; j > left; --j)
					items[j] = items[j - 1];

				items[left] = value;
			}
		}
	}
}
