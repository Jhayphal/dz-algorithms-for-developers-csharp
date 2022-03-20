using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ArrayUnique
{
	public class Tests
	{
		[Test(Description = "Learning letters")]
		[TestCase("АААФФФФФФФЖЫЫЫЫБЫРВАААААЛГГГХЫХЫБЛИА")]
		[TestCase("ОК")]
		[TestCase("СКИЛЛБОКСТОПЧИК")]
		[TestCase("ААААААААА")]
		public void LettersLearnedTodayTest(string word)
		{
			var actual = ArrayUnique.LettersLearnedToday(word);
			var expected = word.ToCharArray().GroupBy(p=>p).Select(p=>p.Key).ToArray();

			Assert.AreEqual(actual.Count, expected.Length);
			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		private static readonly object[] providerAvoidJailDueToTaxFraud =
		{
			new int[][]
			{
				new int []  {12391203, 3828382, 334934939},
				new int []  {45345345, 5341312, 55345345},
				new int []  {334934939, 1234122, 657657},
			},
			new int[][]
			{
				new int []  {1, 1, 1},
				new int []  {1, 1, 1}
			},
			new int[][]
			{
				new int []  {1, 2, 3},
				new int []  {4, 5, 6},
			}
		};
		[Test(Description = "Avoiding jail due to tax fraud")]
		[TestCaseSource(nameof(providerAvoidJailDueToTaxFraud))]
		public void AvoidJailDueToTaxFraudTest(int[][] report)
		{
			var actual = ArrayUnique.AvoidJailDueToTaxFraud(report);
			var expected = new List<int>();
			foreach (var tenant in report)
			{
				foreach (var deal in tenant)
				{
					expected.Add(deal);
				}
			}
			var result = expected.GroupBy(p => p).Where(p => p.Count() > 1).FirstOrDefault()?.Key ?? -1;
			Assert.AreEqual(result, actual);
		}
	}
}