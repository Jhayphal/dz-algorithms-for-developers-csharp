using NUnit.Framework;
using System.Linq;

namespace Duplicates
{
	public class Tests
	{
		[Test]
		public void Test1()
		{
			var data = new int[] { 4, 1, 2, 2 };
			data.RandomSort();

			Assert.AreEqual(new int[] { 1, 2, 2, 4 }, data);


			char[][] words = new char[][] {
				new char [] {'ш', 'б', 'а', 'к', 'а' },
				new char [] { 'б', 'а', 'к', 'а', 'ш'}, // бакаш, вместо шбака
				new char [] {'к', 'а', 'т', 'e', 'н', 'к' },
				new char [] {'г', 'у', 'с', 'ъ', 'к' },
				new char [] {'ш', 'б', 'а', 'к', 'а' }
			};

			SaveChildren.PermutateWords(words);

			Assert.AreEqual(words.Length, words.Select(x => new string(x)).GroupBy(x => x).Count());
		}
	}
}