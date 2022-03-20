using NUnit.Framework;
using System;
using System.Linq;

namespace TopX
{
	public class Tests
	{
		private static readonly object[] providerFindTopElements =
		{
					// Это только один из примеров, при которых код не работает
					// Вам нужно найти еще!
					new object [] { new int[] { 10, 20, 30, 40 }, -1},
		};
		[Test(Description = "Finding top elements")]
		[TestCaseSource(nameof(providerFindTopElements))]
		public void FindTopElementsThrowsTest(int[] array, int numberOfElements)
		{
			Assert.DoesNotThrow(() => TopX.FindTopElements(array, numberOfElements));
		}

		private static readonly object[] providerFindBottomElements =
		{
			new object[] { new int[] { 40, 50, 60, 10, 20, 30, 70, 80 }, 3 },
		};
		 
		[TestCaseSource(nameof(providerFindBottomElements))]
		public void FindBottomElementsTest(int[] array, int numberOfElements)
		{
			var actual = TopX.FindBottomElements(array, numberOfElements);
			Array.Sort(array);
			var expected = new int[numberOfElements];
			Array.Copy(array, expected, numberOfElements);
			
			var actualStr = $"Actual: {string.Join(" ", actual)}";
			var expectedStr = $"Expected: {string.Join(" ", expected)}";

			Assert.AreEqual(expected.Length, actual.Length);
			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}

		private static readonly object[] providerFindTopElementsWithRepeating =
		{
			new object[] { new int[] { 100, 100, 100, 55, 8 }, 3},
			new object[] { new int[] { 100, 100, 100, 55, 8 }, 2 },
			new object[] { new int[] { 100, 55, 8, 100, 100 }, 4 },
			new object[] { new int[] { 0, 0, 0, 0 }, 4 },
		};
		[Test(Description = "Dealing with repeating elements")]
		[TestCaseSource(nameof(providerFindTopElementsWithRepeating))]
		public void FindTopElementsWithRepeatingTest(int[] array, int numberOfElements)
		{
			var actual = TopX.FindTopElements(array, numberOfElements);
			Array.Sort(array);
			var expected = array.Reverse().Take(numberOfElements).ToArray();
			Assert.AreEqual(expected.Length, actual.Length);
			for (int i = 0; i < expected.Length; i++)
			{
				Assert.AreEqual(expected[i], actual[i]);
			}
		}
	}
}