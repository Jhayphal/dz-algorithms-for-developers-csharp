using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class BubbleSort
	{
		//Реализовать метод сортировки пузырьком
		public static void Sort(int[] array)
		{
			for (int j = 1; j < array.Length; ++j)
				for (int i = 0; i < array.Length - j; ++i)
					if (array[i] > array[i + 1])
						Swap(array, i, i + 1);
		}

		private static void Swap(int[] array, int indexA, int indexB)
		{
			int temp = array[indexA];
			array[indexA] = array[indexB];
			array[indexB] = temp;
		}
	}
}
