using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject.Algorithms
{
	public class MergeSort
	{
		public static void Sort(Item[] items)
		{
			if (items.Length < 2)
				return;

			int middle = items.Length >> 1;

			int count = middle;
			var left = new Item[count];
			Array.Copy(items, left, count);

			Sort(left);

			count = items.Length - middle;
			var right = new Item[count];
			Array.Copy(items, middle, right, 0, count);

			Sort(right);

			var result = Merge(left, right);

			Array.Copy(result, items, result.Length);
		}

		private static Item[] Merge(Item[] a, Item[] b)
		{
			var result = new Item[a.Length + b.Length];
			
			int aIndex = 0;
			int bIndex = 0;
			
			int resultIndex = 0;

			while(resultIndex < result.Length)
			{
				if (aIndex == a.Length)
					result[resultIndex++] = b[bIndex++];

				else if (bIndex == b.Length)
					result[resultIndex++] = a[aIndex++];

				else if (a[aIndex].CompareTo(b[bIndex]) < 0)
					result[resultIndex++] = a[aIndex++];
				else
					result[resultIndex++] = b[bIndex++];
			}

			return result;
		}
	}
}
