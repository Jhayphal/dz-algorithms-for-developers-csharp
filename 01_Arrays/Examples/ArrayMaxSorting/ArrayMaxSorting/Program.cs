using System;

namespace ArrayMaxSorting
{
	class Program
	{
		static void Main(string[] args)
		{
			// Объявим массив, который будет содержать, например, возраста всех членов семьи.
			int[] ages = new int[] { 49, 31, 19, 66, 94, 27, 15 };

			// Функция Arrays.sort отсортирует этот массив по возрастанию,
			// в начале будет самый маленький элемент, а в конце самый большой
			Array.Sort(ages);

			//Теперь нам достаточно всего лишь взять последний элемент
			// (т.к. индексы начинаются с нуля, то индекс последнего элемента - это длина массива минус один).
			int maxAge = ages[ages.Length - 1]; //будет равен 94

			Console.WriteLine($"MaxAge = {maxAge}");
			Console.ReadLine();
		}
	}
}
