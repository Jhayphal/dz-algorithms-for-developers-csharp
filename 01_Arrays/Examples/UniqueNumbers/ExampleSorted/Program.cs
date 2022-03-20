using System;
using System.Collections.Generic;

namespace ExampleSorted
{
	public class Program
	{
		static void Main(string[] args)
		{
			long[] phoneNumbers = new long[]{
				+79000000000L, +79000000000L,
				+79000000001L,
				+79000000002L, +79000000002L,
				+79000000003L, +79000000003L, +79000000003L, +79000000003L,
				+79000000004L
		};

			List<long> uniqueNumbers = FindUniqueSorted(phoneNumbers);
			Console.WriteLine($"Unique numbers: {string.Join(" ", uniqueNumbers)}");
			Console.ReadLine();
		}


		// Запустите BenchmarkSorted чтобы посмотреть сколько времени занимает выполнение этого кода
		public static List<long> FindUniqueSorted(long[] phoneNumbers)
		{
			List<long> uniqueNumbers = new List<long>();
			// Возьмем самый первый элемент
			long prevNumber = phoneNumbers[0];

			// И начнем двигаться по массиву начиная со второго элемента
			for (int i = 1; i < phoneNumbers.Length; i++)
			{
				// Как только текущий элемент не равен предыдущему —
				// Бинго! Предыдущий элемент уже можно записывать как уникальный
				if (phoneNumbers[i] != prevNumber)
				{
					uniqueNumbers.Add(prevNumber);
					prevNumber = phoneNumbers[i];
				}
			}

			// В конце у нас останется последний элемент массива,
			// нужно не забыть его тоже положить в массив уникальных элементов
			uniqueNumbers.Add(prevNumber);
			return uniqueNumbers;
		}

		/*
            ————————————————————————
            —— Подумать на досуге ——
            ————————————————————————

            Заметьте, что нам нужно последовательно сравнивать пары элементов массива.
            Нулевой с первым, первый со вторым, второй с третьим и т.д.
            Это классическая подзадача, которая постоянно встречается в разных алгоритмах,
            и решать ее можно по-разному.

            Один из способов это итерация не по всему массиву,
            а например начиная с индекса 1 (как в этом примере),
            или наоборот итерация не до конца а только до предпоследнего элемента.


            Также можно итерироваться с начала и до конца,
            но предусмотреть специальные условия в теле цикла для первого или последнего элемента.
            (Упражнение на разминку мелкой кодерской моторики)

            Попробуйте переписать алгоритм с использованием циклов:

            (1)  for(int i=0; i<phoneNumbers.Length - 1; i++)
            (2)  for(int i=0; i<phoneNumbers.Length; i++)

         */
	}
}
