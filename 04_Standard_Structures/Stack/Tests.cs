using NUnit.Framework;
using System.Text;

namespace Stack
{
	public class Tests
	{
		[Test]
		public void TestPolish()
		{
			Assert.AreEqual(-102, Stack.CalcPolish("8 9 + 1 7 - *"));
			Assert.AreEqual(387420489, Stack.CalcPolish("9 9 9 9 9 9 9 9 9 * * * * * * * *"));
			Assert.AreEqual(-985, Stack.CalcPolish("2 3 4 5 * 6 - 7 + 8 9 2 * 3 4 1 - 3 4 + * 5 - + * + - * +"));
			Assert.AreEqual(-1097349120, Stack.CalcPolish("1 2 - 1 2 3 4 5 6 7 8 9 * * * * * * * * * 9 8 7 6 * * * *"));
			Assert.AreEqual(1234, Stack.CalcPolish("1234"));
			Assert.AreEqual(-1234, Stack.CalcPolish("-1234"));
			Assert.AreEqual(1236, Stack.CalcPolish("1234 1 1 + +"));
			var stringBuilder = new StringBuilder();
			for (int i = 0; i < 10000; ++i)
			{
				stringBuilder.Append(i + " ");
			}
			for (int i = 0; i < 10000; ++i)
			{
				stringBuilder.Append("+");
				if (i != 9999)
				{
					stringBuilder.Append(" ");
				}
			}
			Assert.AreEqual((10000 * 9999) / 2, Stack.CalcPolish(stringBuilder.ToString()));
			stringBuilder = new StringBuilder();
			stringBuilder.Append("0 ");
			for (int i = 0; i < 20000; ++i)
			{
				stringBuilder.Append(i + " +");
				if (i != 19999)
				{
					stringBuilder.Append(" ");
				}
			}
			Assert.AreEqual((20000 * 19999) / 2, Stack.CalcPolish(stringBuilder.ToString()));
		}
	}
}