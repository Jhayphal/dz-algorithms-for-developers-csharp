using NUnit.Framework;

namespace Courses
{
	public class Tests
	{
		private static readonly object[] providerCanFinishTest =
		{
		new object[] {2,  new int[,]{ { 1, 0 } } , true},
		new object[] {2,  new int[,]{ { 1, 0 }, { 0, 1 } } , false},
		new object[] {5,  new int[,]{ { 4, 3 }, { 3, 2 }, { 2, 1 }, { 1, 0 } } , true},
	};

		[Test(Description = "Can you finish all Skillbox cources")]
		[TestCaseSource(nameof(providerCanFinishTest))]
		public void CanFinishTest(int numCourses, int[,] prerequisites, bool result)
		{
			var actual = Courses.CanFinish(numCourses, prerequisites);
			var expected = result;

			Assert.AreEqual(actual, expected);
		}
	}
}