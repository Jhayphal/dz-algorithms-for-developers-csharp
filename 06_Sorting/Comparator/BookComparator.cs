using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparator
{
	public class BookComparator
	{
		//Реализовать сравнение книг только по цене, вначале самые дешевые
		public static int CompareBooksByPrice(Book first, Book second)
		{
			return first.Price.CompareTo(second.Price);
		}

		//Реализовать сравнение книг вначале по авторуб потом по названию, затем по году публикации
		public static int CompareBooksByAuthorAndTitleAndYear(Book first, Book second)
		{
			int result = first.Author.CompareTo(second.Author);

			if (result != 0)
				return result;

			result = first.Title.CompareTo(second.Title);

			if (result != 0)
				return result;

			return first.Year.CompareTo(second.Year);
		}
	}
}