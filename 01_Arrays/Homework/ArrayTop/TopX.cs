using NUnit.Framework;
using System;

namespace TopX
{
	public class TopX
	{
		private static int FindMaxUnderBoundary(int[] inputArray, int topBoundary)
		{
			if (inputArray == null)
				throw new Exception();

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

		public static int[] FindTopElements(int[] inputArray, int numberOfElements)
		{
			// если не указали количнство минимумов - возвращаем пустой массив
			if (numberOfElements <= 0)
				return new int[0];

			// создаем массив результатов
			int[] result = new int[numberOfElements];

			// заполняем его самыми большими значениями
			for (int i = 0; i < numberOfElements; ++i)
				result[i] = int.MinValue;

			// берем каждый элемент
			foreach (var item in inputArray)
				for (int j = 0; j < numberOfElements; ++j)
				{
					// если он меньше, чем какой-либо элемент в массиве результатов
					if (item >= result[j])
					{
						// если текущий элемент результатов уже содержит значение
						if (result[j] != int.MinValue)
							// сдвигаем его вправо вместе с последующими элементами
							for (int k = numberOfElements - 1; k > j; --k)
								if (result[k - 1] != int.MinValue) // нет смысла сдвигать еще не заполненные элементы
									result[k] = result[k - 1];

						// записываем новый меньший элемент
						result[j] = item;

						// дальше смысла идти нет - мы уже нашли место для нового наименьшего элемента
						break;
					}
				}

			return result;

		}

		public static int[] FindBottomElements(int[] inputArray, int numberOfElements)
		{
			// если не указали количнство минимумов - возвращаем пустой массив
			if (numberOfElements <= 0)
				return new int[0];

			// создаем массив результатов
			int[] result = new int[numberOfElements];

			// заполняем его самыми большими значениями
			for (int i = 0; i < numberOfElements; ++i)
				result[i] = int.MaxValue;

			// берем каждый элемент
			foreach(var item in inputArray)
				for (int j = 0; j < numberOfElements; ++j)
				{
					// если он меньше, чем какой-либо элемент в массиве результатов
					if (item < result[j])
					{
						// если текущий элемент результатов уже содержит значение
						if (result[j] != int.MaxValue)
							// сдвигаем его вправо вместе с последующими элементами
							for (int k = numberOfElements - 1; k > j; --k)
								if (result[k - 1] != int.MaxValue) // нет смысла сдвигать еще не заполненные элементы
									result[k] = result[k - 1];

						// записываем новый меньший элемент
						result[j] = item;

						// дальше смысла идти нет - мы уже нашли место для нового наименьшего элемента
						break;
					}
					else if (item == result[j]) // если такой элемент уже есть в списке - игнорируем его
						break;
				}

			// 
			return result;
		}

		[Test(Description = "Пример для запуска в Debug")]
		public static void Example()
		{
			int[] array = new int[] { 10, 66, 4, 16, 99, 35, 11, 123 };

			int[] top5 = FindTopElements(array, 5);
			var top5str = "Top 5: " + string.Join(" ", top5);


			int[] top8 = FindTopElements(array, 8);
			var top8str = "Top 8: " + string.Join(" ", top8);
		}
	}
}
