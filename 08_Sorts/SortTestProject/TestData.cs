using System;
using System.Linq;

namespace SortTestProject
{
	public class TestData
	{
		public readonly Item[] testArray;
		public readonly Item[] expected;
		public readonly long compareToAmount;

		public override string ToString()
		{
			return $"[{ string.Join(", ", testArray.Select(p => p.getData()))}]";

		}

		public TestData(int[] testArray, int[] expected, long compareToAmount)
		{
			this.compareToAmount = compareToAmount;
			this.testArray = testArray.Select(p => new Item(p)).ToArray();
			this.expected = expected.Select(p => new Item(p)).ToArray();
		}

		public static TestData CreateArguments(int[] testData, long compareToAmount)
		{
			int[] sorted = new int[testData.Length];
			Array.Copy(testData, sorted, testData.Length);
			Array.Sort(sorted);
			return new TestData(testData, sorted, compareToAmount);
		}

		public string ReadableDifferenceBetweenArrays()
		{
			return $"Extended array [{string.Join(", ", expected.Select(p => p.getData()))}]{Environment.NewLine}  Actual array   [{string.Join(", ", testArray.Select(p => p.getData()))}]";
		}
	}
}
