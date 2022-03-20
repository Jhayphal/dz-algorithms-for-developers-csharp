using NUnit.Framework;

namespace UnobviousGraphs
{
	public class PathTest
	{
		private static readonly object[] map = new object[]
	   {

				 new object[] {
					new int[,] {
					{0, 1, 5, 5, 1, 1, 2},
					{1, 1, 5, 5, 1, 1, 1},
					{1, 1, 8, 2, 2, 2, 1},
					{8, 8, 8, 2, 2, 1, 1},
					{8, 2, 2, 8, 1, 1, 0}}, 17 },
				new object[] {
					new int[,]{
					{0, 1, 1},
					{1, 1, 1},
					{1, 1, 0}}, 3 },
				new object[] {
					new int[,]{
					{0, 1, 5},
					{2, 8, 1},
					{2, 2, 0}}, 6 },
				new object[] {
					new int[,]{
					{0, 1, 2},
					{1, 2, 5},
					{2, 5, 8},
					{5, 8, 0}}, 16 },
				new object[] {
					new int[,]{
					{0, 1, 5, 5, 1, 1, 2, 1, 1, 5, 5, 2, 1, 2, 1, 1, 5, 5, 1, 1, 2},
					{1, 1, 5, 5, 1, 1, 1, 1, 1, 5, 5, 2, 1, 1, 1, 1, 5, 5, 1, 1, 1},
					{1, 1, 8, 2, 2, 2, 1, 1, 1, 8, 2, 2, 2, 1, 1, 1, 8, 2, 2, 2, 1},
					{8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 1, 5, 8, 8, 8, 2, 2, 1, 5, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 1, 5, 8, 8, 8, 2, 2, 1, 5, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 1, 1, 8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 1, 1, 8, 8, 8, 2, 2, 1, 5, 8, 8, 8, 2, 2, 1, 1},
					{8, 8, 8, 2, 2, 1, 1, 8, 8, 8, 2, 2, 5, 1, 8, 8, 8, 2, 2, 1, 1},
					{8, 2, 2, 8, 1, 1, 1, 8, 2, 2, 8, 1, 1, 0, 8, 2, 2, 8, 1, 1, 0}}, 54 },
				new object[] {
					new int[,]{
					{0, 1, 2},
					{1, 2, 5},
					{2, -10, 8},
					{5, 8, 0}}, 1 }
		};


		[Test(Description = "Path to princess-frog")]
		[TestCaseSource(nameof(map))]
		public void ValidProject(int[,] map, int expectedHours)
		{
			Assert.AreEqual(expectedHours, Path.ShortestPathDuration(map));
		}
	}
}
