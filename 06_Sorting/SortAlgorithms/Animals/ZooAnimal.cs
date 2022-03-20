using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{

	public class ZooAnimal : IAnimal
	{
		private readonly int Weight;
		private readonly string Name;

		public ZooAnimal(int weight, String name)
		{
			Weight = weight;
			Name = name;
		}


		public int GetWeight()
		{
			return Weight;
		}


		public override string ToString()
		{
			return string.Format("ZooAnimal: Weight={0, 4}, Name={1,10}", Weight, Name);
		}

		public static void Sort(IAnimal[] array)
		{
			for (int left = 0; left < array.Length; left++)
			{
				var value = array[left];
				int i = left - 1;
				for (; i >= 0; i--)
				{
					if (value.GetWeight() < array[i].GetWeight())
					{
						array[i + 1] = array[i];
					}
					else
					{
						break;
					}
				}
				array[i + 1] = value;
			}
		}
	}
}
