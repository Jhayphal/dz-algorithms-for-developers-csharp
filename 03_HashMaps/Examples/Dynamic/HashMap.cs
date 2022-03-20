using System;
using System.Collections.Generic;

namespace Dynamic
{
	public class HashMap
	{
		private KeyValuePair<string, string>[] entries = new KeyValuePair<string, string>[8];
		private int size = 8;
		private int numberOfElements = 0;

		int HashFunction(string key)
		{
			//
			return 0;
		}

		public void Add(string key, string value)
		{
			int index = FindGoodIndex(key);
			entries[index] = new KeyValuePair<string, string>(key, value);
			numberOfElements++;
			if (numberOfElements == size)
			{
				Resize(size * 2);
			}
		}

		public void Resize(int newSize)
		{
			// Создать новый массив
			KeyValuePair<string, string>[] newEntries = new KeyValuePair<string, string>[newSize];

			// Скопировать 8 элементов из старого массива
			for (int i = 0; i < size; i++)
			{
				var entry = entries[i];
				int index = FindGoodIndex(entry.Key);
				newEntries[index] = entry;
			}
			entries = newEntries;
			size = newSize;
		}

		public string Get(string key)
		{
			int index = FindGoodIndex(key);
			if (index == -1)
			{
				return null;
			}
			var entry = entries[index];
			return entry.Value;
		}

		int FindGoodIndex(String key)
		{
			int hash = HashFunction(key);
			int index = hash % size;

			for (int i = 0; i < size; i++)
			{
				int probingIndex = (index + i) % size;
				var entry = entries[probingIndex];
				if (entry.Key == null || entry.Key.Equals(key))
				{
					return probingIndex;
				}
			}
			return -1;
		}
	}
}
