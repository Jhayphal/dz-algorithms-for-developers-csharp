using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace VeryDynamic
{
	public class DynamicHashMap<Tkey, TValue> : Dictionary<Tkey, TValue>
	{
		public void DeleteKey(Tkey key)
		{
			// я не понял, чего вы от меня хотите
			Remove(key);
		}

		public Tkey[] GetAllKeys()
		{
			Tkey[] result = new Tkey[Keys.Count];
			int currentIndex = 0;

			foreach (var key in Keys)
				result[currentIndex++] = key;

			return result;
		}

		public TValue[] GetAllValues()
		{
			TValue[] result = new TValue[Values.Count];
			int currentIndex = 0;

			foreach (var value in Values)
				result[currentIndex++] = value;

			return result;
		}		
	}

	public class Tests
	{
		[Test]
		public void Test1()
		{
			var keys = new string[] { "test", "best", "west", "mest", "fest", "dest" };

			var data = new DynamicHashMap<string, int>();

			for (int i = 0; i < keys.Length; ++i)
				data.Add(keys[i], i);

			Assert.AreEqual(keys, data.GetAllKeys());
			Assert.AreEqual(Enumerable.Range(0, keys.Length).ToArray(), data.GetAllValues());

			data.DeleteKey(keys[1]);

			Assert.AreEqual(keys.Length - 1, data.Count);
			Assert.AreEqual(keys.Take(1).Concat(keys.Skip(2)).ToArray(), data.GetAllKeys());
		}
	}
}