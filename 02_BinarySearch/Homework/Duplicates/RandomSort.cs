using System;

namespace Duplicates
{
	public static class RandomSortExtension
	{
		public static bool MyIsSorted(int[] array)
		{
			int length = array?.Length ?? 0;

			if (length < 2)
				return true;

			// если расскоментировать эту строку метод будет определять отсортирован ли массив независимо от порядка сортировки
			// bool? descend = null;
			bool? descend = false;

			for (int i = 1; i < length; ++i)
			{
				int difference = array[i - 1] - array[i];

				if (difference == 0)
					continue;

				if (descend.HasValue)
				{
					if ((difference > 0) != descend)
						return false;
				}
				else
					descend = difference > 0;
			}

			return true;
		}


		public static void RandomSort(this int[] array)
		{
			int length = array?.Length ?? 0;

			if (length == 0)
				return;

			Random random = new Random(DateTime.Now.Millisecond);

			while (!MyIsSorted(array))
			{
				var index1 = random.Next(0, length);
				var index2 = random.Next(0, length);

				if (index1 == index2)
					continue;

				//array[index1] ^= array[index2];
				//array[index2] ^= array[index1];
				//array[index1] ^= array[index2];

				array[index1] = (array[index2] ^= (array[index1] ^= array[index2])) ^ array[index1];
			}
		}
	}
}
