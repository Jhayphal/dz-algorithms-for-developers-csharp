using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BruteForceRecursion
{
	public class BruteForceRecursionTest
	{
		private static void AssertEqualsList(List<int> expected, List<int> actual)
		{
			Assert.AreEqual(expected, actual,
				$"Extended list {Environment.NewLine}{string.Join(" ", expected)}" +
				$"{Environment.NewLine}  Actual list {Environment.NewLine}{string.Join(" ", actual)}");
		}

		private static readonly object[] ProviderOrderOfReleaseFeaturesTest =
		{
			new object[]{new int[] { 1, 2, 3 }, new List<List<int>>
			{
				new List<int> { 1, 2, 3 },
				new List<int> { 1, 3, 2 },
				new List<int> { 2, 1, 3 },
				new List<int> { 2, 3, 1 },
				new List<int> { 3, 1, 2 },
				new List<int> { 3, 2, 1 }
			}},
			new object[]{new int[] { 13, 21 }, new List<List<int>>
			{
				new List<int> {13, 21 },
				new List<int> { 21, 13 }
			}},
			new object[]{new int[] { 98 }, new List<List<int>>
			{
				new List<int> {98}
			}}
		};

		[Test(Description = "Find all possible order of release features")]
		[TestCaseSource(nameof(ProviderOrderOfReleaseFeaturesTest))]
		public void OrderOfReleaseFeaturesTest(int[] numbersOfFeatures, List<List<int>> expected)
		{
			var actual = BruteForceRecursion.OrderOfReleaseFeatures(numbersOfFeatures);
			for (int i = 0; i < expected.Count; i++)
			{
				AssertEqualsList(expected[i], actual[i]);
			}
		}


		[Test(Description = "Help Ivan check powers of 3")]
		[TestCase(12)]
		[TestCase(91)]
		[TestCase(21)]
		public void CheckPowersOfThreeTest(int number)
		{
			var actual = BruteForceRecursion.CheckPowersOfThree(number);
			var expected = number != 21;
			Assert.AreEqual(expected, actual);
		}


		private static readonly object[] ProviderPossibleMessagesTest =
		{
			new object[] {"", new List<string>() },
			new object[]{"2", new List<string>{"a", "b", "c" } },
			new object[]{"43", new List<string>{"gd", "ge", "gf", "hd", "he", "hf", "id", "ie", "if" } },
			new object[]{"239", new List<string>
				{
					"adw", "adx", "ady", "adz",
					"aew", "aex", "aey", "aez",
					"afw", "afx", "afy", "afz",
					"bdw", "bdx", "bdy", "bdz",
					"bew", "bex", "bey", "bez",
					"bfw", "bfx", "bfy", "bfz",
					"cdw", "cdx", "cdy", "cdz",
					"cew", "cex", "cey", "cez",
					"cfw", "cfx", "cfy", "cfz"
				}}
		};

		[Test(Description = "Find possible messages")]
		[TestCaseSource(nameof(ProviderPossibleMessagesTest))]
		public void PossibleMessagesTest(string number, List<string> messages)
		{
			var actual = new HashSet<string>(BruteForceRecursion.PossibleMessages(number));
			var expected = new HashSet<string>(messages);

			Assert.AreEqual(expected, actual,
				$"Extended HashSet {Environment.NewLine}{string.Join(" ", expected)}" +
				$"{Environment.NewLine}  Actual HashSet {Environment.NewLine}{string.Join(" ", actual)}");
		}
	}
}