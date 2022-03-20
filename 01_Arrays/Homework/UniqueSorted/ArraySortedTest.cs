using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace UniqueSorted
{
	public class Tests
	{
		private static readonly object[] providerGroupAndPrint =
		{
					new long[]{
						79000000000L,
						79000000000L,
						79000000001L,
						79000000002L,
						79000000002L,
						79000000003L,
						79000000003L,
						79000000003L,
						79000000003L,
						79000000004L,
					}
		};

		[Test(Description = "Group phone numbers")]
		[TestCaseSource(nameof(providerGroupAndPrint))]
		public void GroupAndPrintTest(long[] numbers)
		{
			var actual = ArraySorted.GroupAndPrint(numbers);
			var expected = numbers.GroupBy(p => p).ToDictionary(p => p.Key, p => p.Count());

			Assert.AreEqual(expected.Count, actual.Count);
			foreach (var item in actual)
			{
				Assert.AreEqual(expected[item.Key], item.Value);
			}
		}

		public class CurrencyAmount
		{
			public readonly string Name;
			public readonly int Amount;

			public CurrencyAmount(string name, int amount)
			{
				Name = name;
				Amount = amount;
			}

			public override string ToString()
			{
				return $"{Name}:{Amount}";
			}
		}

		private static readonly object[] providerCryptoCurrencyAnalysis =
			{
			new List<CurrencyAmount>()
			{
							new CurrencyAmount("BTC", 42),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 900),
							new CurrencyAmount("DOGE", 123456),
							new CurrencyAmount("DOGE", 69420),
							new CurrencyAmount("ETH", 220),
							new CurrencyAmount("ETH", 666),
							new CurrencyAmount("XMR", 14),
							new CurrencyAmount("XMR", 88)
			},
				new List<CurrencyAmount>()
			{
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600),
							new CurrencyAmount("BTC", 600)
					},
					new List<CurrencyAmount>()
			{
							new CurrencyAmount("BTC", 1),
							new CurrencyAmount("DOGE", 2)
					},
					new List<CurrencyAmount>()
			{
							new CurrencyAmount("DOGE", 69420)
					}
		};

		[Test(Description = "Crypto currency analysis")]
		[TestCaseSource(nameof(providerCryptoCurrencyAnalysis))]
		public void CryptoCurrencyAnalysisTest(List<CurrencyAmount> contents)
		{
			var file = string.Join(Environment.NewLine, contents.Select(p => p.ToString()));
			var actual = ArraySorted.CryptoCurrencyAnalysis(file);

			var expected = contents.GroupBy(p => p.Name).ToDictionary(p => p.Key, p => p.Average(t => t.Amount));

			Assert.AreEqual(expected.Count, actual.Count);
			foreach (var item in actual)
			{
				Assert.AreEqual(expected[item.Key], item.Value);
			}
		}
	}
}