using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Comparator
{
	public class Tests
	{
		private static void AssertEqualsArray(List<Book> expected, List<Book> actual)
		{
			Assert.AreEqual(expected, actual,
				$"Extended array {Environment.NewLine}{string.Join(Environment.NewLine, expected)}" +
				$"{Environment.NewLine}  Actual array{Environment.NewLine}{string.Join(Environment.NewLine, actual)}");
		}

		private static readonly object[] algoBooks = new List<Book>[]
		{
			new List<Book>()
			{
				new Book("Грокаем алгоритмы", "Адитья Бхаргава", 2017, 500.0),
				new Book("Совершенный алгоритм. Основы", "Тим Рафгарден", 2019, 1500.0),
				new Book("Совершенный алгоритм. Графовые алгоритмы и структуры данных", "Рафгарден Тим", 2019, 999.0),
				new Book("Алгоритмы для начинающих", "Луридас Панос", 2018, 499.0),
				new Book("Грокаем алгоритмы", "Адитья Бхаргава", 2021, 700.0),
				new Book("Введение в анализ алгоритмов", "Майкл Солтис", 2019, 500.0),
				new Book("Алгоритмы: разработка и применение", "Джон Клейнберг", 2016, 100.0)
			}
		};

		[Test(Description = "Sort books by price")]
		[TestCaseSource(nameof(algoBooks))]
		public void СompareBooksByPriceTest(List<Book> books)
		{
			var expectedList = books.OrderBy(p => p.Price).ToList();
			books.Sort(BookComparator.CompareBooksByPrice);
			AssertEqualsArray(expectedList, books);
		}

		[Test(Description = "Sort books by author, title, year")]
		[TestCaseSource(nameof(algoBooks))]
		public void CompareBooksByAuthorAndYearAndPriceTest(List<Book> books)
		{
			var expectedList = books.OrderBy(p => p.Author).ThenBy(p => p.Price).ThenBy(p => p.Year).ToList();
			books.Sort(BookComparator.CompareBooksByAuthorAndTitleAndYear);
			AssertEqualsArray(expectedList, books);
		}


		[Test(Description = "Find book")]
		[TestCaseSource(nameof(algoBooks))]
		public void BookCompareToTest(List<Book> books)
		{
			var expectedList = books.OrderBy(p => p.Author).ThenBy(p => p.Title).ThenBy(p => p.Price).ThenBy(p => p.Year).ToList();
			books.Sort();
			AssertEqualsArray(expectedList, books);
		}
	}
}