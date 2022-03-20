using NUnit.Framework;

namespace RandomizedAlgorithms
{
	public class RandomizedAlgorithmsTest
	{

		private static readonly int[] providerDots = new int[] { 100, 1000, 10000, 100000, 1000000 };

		[Test(Description = "Calculate PI")]

		[TestCaseSource(nameof(providerDots))]

		public void findPiTest(int dots)
		{
			var pi = RandomizedAlgorithms.FindPi(dots);

			Assert.IsTrue(pi > 2.5 && pi < 4D, "Value of PI < 2.5 or > 4");
		}
	}
}