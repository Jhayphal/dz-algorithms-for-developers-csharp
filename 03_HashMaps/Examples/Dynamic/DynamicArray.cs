using System;

namespace Dynamic
{
	public class DynamicArray
	{
		int[] values = new int[8];
		int size = 8;
		int currentIndex = 0;

		public void Add(int value)
		{
			values[currentIndex] = value;
			currentIndex++;
			if (currentIndex == size)
			{
				Resize(size * 2);
			}
		}

		public void Resize(int newSize)
		{
			int[] newValues = new int[newSize];
			for (int i = 0; i < size; i++)
			{
				newValues[i] = values[i];
			}
			values = newValues;
			size = newSize;
		}
	}
}
