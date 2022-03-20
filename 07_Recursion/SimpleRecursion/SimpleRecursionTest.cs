using NUnit.Framework;

namespace SimpleRecursion
{
	public class SimpleRecursionTest
	{
		private static int FindIterationFibonacci(int n)
		{
			// Declare an array to store Fibonacci numbers. 
			int[] f = new int[n + 2]; // 1 extra to handle case, n = 0
			int i;

			// 0th and 1st number of the series are 0 and 1
			f[0] = 0;
			f[1] = 1;

			for (i = 2; i <= n; i++)
			{
				// Add the previous 2 numbers in the series  and store it 
				f[i] = f[i - 1] + f[i - 2];
			}

			return f[n];
		}


		[Test(Description = "Find number of Fibonacci")]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(7)]
		[TestCase(12)]
		public void FindFibonacciTest(int n)
		{
			var actual = SimpleRecursion.FindRecursionFibonacci(n);
			var expected = FindIterationFibonacci(n);

			Assert.AreEqual(expected, actual);
		}
	}
}