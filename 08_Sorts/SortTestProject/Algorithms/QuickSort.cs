using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject.Algorithms
{
	public class QuickSortAlgorithms
	{
		public static void Sort(Item[] items)
		{
			QuickSort(items, 0, items.Length - 1);
		}

		public static void QuickSort(Item[] array, int low, int high)
		{
			if (array.Length == 0)
				return;//завершить выполнение если длина массива равна 0

			if (low >= high)
				return;//завершить выполнение если уже нечего делить

			// выбрать опорный элемент
			int middle = low + (high - low) / 2;
			Item opora = array[middle];

			// разделить на подмассивы, который больше и меньше опорного элемента
			int i = low, j = high;
			while (i <= j)
			{
				while (array[i].CompareTo(opora) < 0)
				{
					i++;
				}

				while (array[j].CompareTo(opora) > 0)
				{
					j--;
				}

				if (i <= j)
				{
					//меняем местами
					Item temp = array[i];
					array[i] = array[j];
					array[j] = temp;
					i++;
					j--;
				}
			}

			// вызов рекурсии для сортировки левой и правой части
			if (low < j)
				QuickSort(array, low, j);

			if (high > i)
				QuickSort(array, i, high);
		}
	}
}
