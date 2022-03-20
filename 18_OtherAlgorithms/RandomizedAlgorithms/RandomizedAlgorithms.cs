using System;

namespace RandomizedAlgorithms
{
    public static class RandomizedAlgorithms
	{
		public static double FindPi(int dots)
		{
			var random = new Random();

			int inCircleCount = 0;

			for (int i = 0; i < dots; ++i)
				if (GetPointDistanceFromCenter(random.NextDouble(), random.NextDouble()) <= 1D)
					++inCircleCount;

			return 4D * inCircleCount / dots;
		}

		private static double GetPointDistanceFromCenter(double x, double y)
        {
			return Math.Sqrt(x * x + y * y);
        }
	}
}
