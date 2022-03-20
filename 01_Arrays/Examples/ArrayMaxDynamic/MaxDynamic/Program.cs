using System;

namespace MaxDynamic
{
	class Program
	{
		static void Main(string[] args)
		{
			// Возьмем тот же массив что и в примере с сортировкой
			int[] ages = new int[] { 49, 31, 19, 66, 94, 27, 15 };

			int maxAge = 0;

			// И пройдем по нему циклом for
			for (int i = 0; i < ages.Length; i++)
			{
				// На каждом шаге будем обновлять текущий максимум
				maxAge = Math.Max(maxAge, ages[i]);
			}

			// В итоге в maxAge будет абсолютный максимум
			Console.WriteLine($"MaxAge = {maxAge}");
			Console.ReadLine();
		}
	}
}
