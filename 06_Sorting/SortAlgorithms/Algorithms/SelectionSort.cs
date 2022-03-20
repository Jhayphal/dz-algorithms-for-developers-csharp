using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class SelectionSort
	{
		// реализовать метод сортировки выбором
		public static void sort(ISuperArray array)
		{
			int count = array.GetSize();

			for (int i = 0; i < count; ++i)
			{
				int min = array.Get(i);
				int minIndex = i;

				for (int j = i + 1; j < count; ++j)
				{
					int current = array.Get(j);

					if (current < min)
					{
						min = current;
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					int temp = array.Get(i);
					array.Set(i, min);
					array.Set(minIndex, temp);
				}
			}
		}
	}
}
