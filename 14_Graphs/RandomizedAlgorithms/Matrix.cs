using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizedAlgorithms
{
	public class Matrix
	{
		public static int[,] Paint(int[,] image, int row, int col, int newColor)
		{
			if (image[row, col] == newColor)
				return image;

			image[row, col] = newColor;

			var width = image.GetLength(0);
			var height = image.GetLength(1);

			foreach (var (neightboardRow, neightboardCol) in GetNeightboards(row, col, width, height))
				Paint(image, neightboardRow, neightboardCol, newColor);

			return image;
		}

		private static IEnumerable<(int row, int col)> GetNeightboards(int row, int col, int width, int height)
        {
			if (row > 0)
				yield return (row - 1, col);

			if (col > 0)
				yield return (row, col - 1);

			if (row > 0 && col > 0)
				yield return (row - 1, col - 1);

			if (row < width - 1)
				yield return (row + 1, col);

			if (col < height - 1)
				yield return (row, col + 1);

			if (row < width - 1 && col < height - 1)
				yield return (row + 1, col + 1);

			if (row > 0 && col < height - 1)
				yield return (row - 1, col + 1);

			if (col > 0 && row < width - 1)
				yield return (row + 1, col - 1);
		}

		public static int NumIslands(char[,] grid)
		{
			int result = 0;

			var width = grid.GetLength(0);
			var height = grid.GetLength(1);

			for (int i = 0; i < width; ++i)
            {
				for (int j = 0; j < height; ++j)
                {
					char x = grid[i, j];

					if (x == '0')
						continue;

					++result;

					DropIsland(grid, i, j, width, height);
                }
            }

			return result;
		}

        private static void DropIsland(char[,] grid, int i, int j, int width, int height)
        {
			if (grid[i, j] == '0')
				return;

			grid[i, j] = '0';

			foreach(var (row, col) in GetIslandsNeightboards(i, j, width, height))
				DropIsland(grid, row, col, width, height);
        }

        private static IEnumerable<(int row, int col)> GetIslandsNeightboards(int row, int col, int width, int height)
		{
			if (row > 0)
				yield return (row - 1, col);

			if (col > 0)
				yield return (row, col - 1);

			if (row < width - 1)
				yield return (row + 1, col);

			if (col < height - 1)
				yield return (row, col + 1);
		}
	}
}
