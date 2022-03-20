using System;

namespace Top2
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] ages = new int[] { 49, 31, 19, 66, 94, 27, 15 };

			int top1Age = 0;
			int top2Age = 0;

			// Найдем первый максимум в массиве
			for (int i = 0; i < ages.Length; i++)
			{
				top1Age = Math.Max(top1Age, ages[i]);
			}

			// Добавим второй проход по массиву
			// И рассмотрим только элементы, которые меньше первого максимума
			for (int i = 0; i < ages.Length; i++)
			{
				if (ages[i] < top1Age)
				{
					top2Age = Math.Max(top2Age, ages[i]);
				}
			}

			Console.WriteLine($"First Max: {top1Age}");
			Console.WriteLine($"Second Max: {top2Age}");
			Console.ReadLine();
		}
	}
}
