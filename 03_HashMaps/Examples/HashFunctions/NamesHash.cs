using NUnit.Framework;

namespace HashFunctions
{
	public class Tests
	{
		private static int[] values = new int[8];

		public int GetIndexByKey(string key)
		{
			return key.Length;
		}

		public int GetValueByKey(string key)
		{
			int index = GetIndexByKey(key);
			return values[index];
		}

		[Test]
		public void Main()
		{
			values[2] = 14; // Ия
			values[3] = 99; // Аня
			values[4] = 30; // Миша
			values[5] = 42; // Антон
			values[6] = 87; // Владик
			values[7] = 71; // Николай

			var result = GetValueByKey("Аня");
			Assert.AreEqual(99, result);
		}
	}
}