using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace HashMapsAreFast
{
	public class Tests
	{
		private int GetHash(long value)
		{
			return (int)value ^ (int)(value >> 32);
		}

		public long[] GetUniqueNumbers(long[] inputArray)
		{
			HashSet<long> values = new HashSet<long>(inputArray);
			return values.ToArray();
		}

		public bool IsThereTwoNumbers(int[] numbers, int X)
		{
			int length = numbers?.Length ?? 0;

			if (length < 2)
				return false;

			Dictionary<int, int> hashMap = new Dictionary<int, int>();

			int value = numbers[0];
			hashMap.Add(X - value, value);

			for (int i = 1; i < length; ++i)
			{
				value = numbers[i];

				int key = X - value;

				if (hashMap.ContainsKey(key))
					return true;

				hashMap.Add(key, value);
			}

			return false;
		}

		[Test]
		public void GetUniqueNumbersTest()
		{
			var data = new long[] { 1, 2, 1, 66666, 22, 34, 233, 5345, 53, -1, 0, 11, 22, -1, -100 };

			Assert.AreEqual(data.GroupBy(x => x).Select(x => x.Key).ToArray(), GetUniqueNumbers(data));
		}

		[Test]
		public void IsThereTwoNumbersTest()
		{
			var data = new int[] { 1, 66, 22, -4, 55, 22 };

			Assert.AreEqual(true, IsThereTwoNumbers(data, 62));
		}
	}
}