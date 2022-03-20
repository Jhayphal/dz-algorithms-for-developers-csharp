using NUnit.Framework;
using System;

namespace RandomizedAlgorithms
{
	public class Tests
	{

		static int[,] matrix = { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } };
		static int[,] targetMatrix = { { 1, 1, 1, 0 }, { 1, 1, 1, 0 }, { 1, 1, 1, 0 }, { 1, 1, 1, 0 } };

		static int[,] matrix2 = { { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } };
		static int[,] targetMatrix2 = { { 0, 0, 1, 1 }, { 0, 0, 1, 1 }, { 0, 0, 1, 1 }, { 0, 0, 1, 1 } };

		private static readonly object[] providerMatrixTest =
		{
		new object[] { matrix, 0, 1, 1, targetMatrix },
		new object[] { matrix2, 0, 3, 1, targetMatrix2 }
	};

		static char[,] grid1 =
			{
			{'1', '1', '1', '1', '0'},
			{'1', '1', '0', '1', '0'},
			{'1', '1', '0', '0', '0'},
			{'0', '0', '0', '0', '0'}
		};

		static char[,] grid2 =
			{
			{'1', '1', '0', '0', '0'},
			{'1', '1', '0', '0', '0'},
			{'0', '0', '1', '0', '0'},
			{'0', '0', '0', '1', '1'}
		};

		private static readonly object[] providerNumIslandsTest =
			{
			new object[] {grid1, 1},
			new object[] {grid2, 3}
		};


		[Test(Description = "Print a matrix")]
		[TestCaseSource(nameof(providerMatrixTest))]
		public void PrintTest(int[,] image, int row, int col, int newColor, int[,] targetImage)
		{
			var actual = Matrix.Paint(image, row, col, newColor);
			AssertEqualsArray(targetImage, actual);
		}


		[Test(Description = "Find count of Islands")]
		[TestCaseSource(nameof(providerNumIslandsTest))]
		public void NumIslandsTest(char[,] grid, int islands)
		{
			var actual = Matrix.NumIslands(grid);
			Assert.AreEqual(islands, actual);
		}

		private static void AssertEqualsArray(int[,] expected, int[,] actual)
		{
			Assert.AreEqual(expected, actual,
				$"Extended array {Environment.NewLine}{string.Join(Environment.NewLine, expected)}" +
				$"{Environment.NewLine}  Actual array{Environment.NewLine}{string.Join(Environment.NewLine, actual)}");
		}
	}
}