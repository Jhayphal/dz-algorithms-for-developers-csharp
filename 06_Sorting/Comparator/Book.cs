using System;

namespace Comparator
{
	public class Book : IComparable
	{
		public string Title { get; }
		public string Author { get; }
		public int Year { get; }
		public double Price { get; }

		public Book(string title, string author, int year, double price)
		{
			Title = title;
			Author = author;
			Year = year;
			Price = price;
		}

		public override string ToString()
		{
			return string.Format("Book: Title={0, 60}, Author={1,16}, Year={2,4}, Price={3,4};", Title, Author, Year, Price);
		}

		public int CompareTo(object obj)
		{
			if (obj is Book book)
			{
				int result = Author.CompareTo(book.Author);

				if (result != 0)
					return result;

				result = Title.CompareTo(book.Title);

				if (result != 0)
					return result;

				result = Price.CompareTo(book.Price);

				if (result != 0)
					return result;

				return Year.CompareTo(book.Year);
			}
			return -1;
		}
	}
}
