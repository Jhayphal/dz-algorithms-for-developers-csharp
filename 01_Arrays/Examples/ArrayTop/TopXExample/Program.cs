using System;

namespace TopXExample
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[] { 10, 66, 4, 16, 99, 35, 11, 123 };

			int[] top5 = findTopElements(array, 5);
			Console.WriteLine($"Top 5: " + string.Join("; ", top5));


			int[] top8 = findTopElements(array, 8);
			Console.WriteLine($"Top 8: " + string.Join("; ", top8));
			Console.ReadLine();
		}

		private static int findMaxUnderBoundary(int[] inputArray, int topBoundary)
		{
			// Найдем текущий максимум
			int currentMax = int.MinValue;
			for (int k = 0; k < inputArray.Length; k++)
			{
				// Рассмотрим только те элементы, которые меньше заданного числа
				if (inputArray[k] < topBoundary)
				{
					currentMax = Math.Max(currentMax, inputArray[k]);
				}
			}
			return currentMax;
		}

		private static int[] findTopElements(int[] inputArray, int numberOfElements)
		{

			// Создадим массив для результата
			int[] topElements = new int[numberOfElements];

			// Нам требуется знать предыдущее значение максимума,
			// По-умолчанию мы положим туда максимальное значение для типа int
			int previousMax = int.MaxValue;

			// Выполним цикл столько раз, сколько максимумов нам нужно найти
			for (int i = 0; i < numberOfElements; i++)
			{
				// Найдем текущий максимум
				int currentMax = findMaxUnderBoundary(inputArray, previousMax);

				// Обновим значение "предыдущего" максимума
				previousMax = currentMax;

				// Положим результат в выходной массив
				topElements[i] = currentMax;
			}
			return topElements;
		}
	}
}
