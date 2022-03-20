using System;

namespace BinarySearch.Common
{
	public static class BinarySearchExtension
	{
		public static int BinarySearch(this int[] array, int search)
		{
			int left = 0;
			int right = array.Length - 1;

			while (left <= right)
			{
				int middle = (left + right) / 2;
				if (array[middle] < search)
				{
					left = middle + 1;
				}
				else if (array[middle] > search)
				{
					right = middle - 1;
				}
				else
				{
					return middle;
				}
			}
			return -1;
		}
	}
}
