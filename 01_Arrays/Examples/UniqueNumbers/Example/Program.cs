using System;
using System.Collections.Generic;

namespace Example
{
	public class Program
	{
		static void Main(string[] args)
		{
			long[] phoneNumbers = new long[] { +79161002030L, +79255558877L, +79219990000L, +79161002030L };
			List<long> uniqueNumbers = FindUnique(phoneNumbers);
			Console.WriteLine($"Unique numbers: {string.Join(" ", uniqueNumbers)}");
			Console.ReadLine();
		}

		/*
        Запустите Benchmark чтобы посмотреть сколько времени занимает выполнение этого кода
		*/
		public static List<long> FindUnique(long[] phoneNumbers)
		{
			// Заведем список уникальных номеров, "Блокнотик"
			List<long> uniqueNumbers = new List<long>();

			// Пройдемся циклом по нашим номерам
			foreach (var currentNumber in phoneNumbers)
			{
				// Проверим есть ли уже этот номер в "Блокнотике"
				var alreadyExists = false;
				foreach (var existingNumber in uniqueNumbers)
				{
					if (currentNumber == existingNumber)
					{
						alreadyExists = true;
						break;
					}
				}

				// Если его там нет — то добавим
				if (!alreadyExists)
				{
					uniqueNumbers.Add(currentNumber);
				}
			}
			return uniqueNumbers;
		}
	}

	/*
        ————————————————————————
        —— Подумать на досуге ——
        ————————————————————————

        Этот пример можно решить многими способами,
        здесь мы намеренно рассматриваем самый явный и примитивный подход,
        чтобы разобраться во времени выполнения этого кода.

        Как бы вы переписали этот кода с использованием всех ваших знаний?
        Как бы изменилось время выполнения этого кода?
    */


	/*
     * 1. В этом примере мы используем List а не обычный массив long[],
     * т.к. в C# такие массивы всегда фиксированного размера.
     *
     * Здесь мы заранее не знаем сколько уникальных номеров у нас должно получиться,
     * поэтому мы используем “динамический” массив List,
     * в который можно добавить сколько угодно элементов.
     *
     * Массивы фиксированного размера характерны для таких языков как Java, C, C++, C#,
     * и практически не встречаются в Python, PHP и JS.
     *
     * Немного позже мы еще вернемся к обсуждению устройства и свойств динамических массивов.
     *
     * Сейчас важно понимать, что для решения этой задачи мы будем использовать именно их.
     *
     *
     * 2. Для простой итерации по массиву, когда индексы элементов для нас не важны,
     * в C# используется упрощенный синтаксис foreach(variable in array),
     * похожая конструкция есть в большинстве других языков программирования.
     *    
     */
}