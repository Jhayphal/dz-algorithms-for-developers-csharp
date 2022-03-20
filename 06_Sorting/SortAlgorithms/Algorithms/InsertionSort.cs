using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class InsertionSort
	{
		// реализовать метод сортировкой вставками
		public static void Sort(IAnimal[] array)
		{
			for (int i = 1; i < array.Length; ++i)
			{
				int left = i - 1;
				int currentWeight = array[i].GetWeight();

				if (currentWeight >= array[left].GetWeight())
					continue;
				
				while (left > 0 && currentWeight < array[--left].GetWeight()) ;

				if (currentWeight >= array[left].GetWeight())
					++left;

				var value = array[i];

				for (int j = i; j > left; --j)
					array[j] = array[j - 1];

				array[left] = value;
			}
		}
	}
}
