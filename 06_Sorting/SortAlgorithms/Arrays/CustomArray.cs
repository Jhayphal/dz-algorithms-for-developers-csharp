using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public class CustomArray : ISuperArray
	{

		private readonly int[] array;
		int iteration = 0;

		public CustomArray(int[] array)
		{
			this.array = array;
		}


		public int GetSize()
		{
			return array.Length;
		}


		public int Get(int position)
		{
			return array[position];
		}


		public void Set(int position, int value)
		{
			iteration++;
			array[position] = value;
		}

		public int GetIteration()
		{
			return iteration;
		}
	}
}
