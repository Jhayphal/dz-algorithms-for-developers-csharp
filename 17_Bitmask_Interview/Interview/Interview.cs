using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
	public class Interview
	{
        public static bool FindSubarray(int[] a, int S)
        {
            var sum = 0;
            var data = new HashSet<int>(a.Length);

            for (int i = 0; i < a.Length; ++i)
            {
                sum += a[i];

                if (sum == S)
                    return true;

                if (data.Contains(sum - S))
                    return true;

                data.Add(sum);
            }

            return false;
        }

        public static void RotateMatric(int[,] a)
        {
            var sideLength = a.GetLength(0);
            var layers = sideLength >> 1;

            for (int i = 0; i < layers; ++i)
            {
                var startFrom = new Point(i, i);
                var innerSideLength = sideLength - (i << 1);

                RotateMatric(a, startFrom, innerSideLength);
            }

            return;
        }

        public static void RotateMatric(int[,] a, Point startFrom, int sideLength)
        {
            for (int x = 0; x < sideLength; ++x) // Вверх-лево
                Swap(
                    a,
                    new Point(x + startFrom.X, startFrom.Y),
                    new Point(startFrom.X, (sideLength + startFrom.X) - x - 1));

            for (int x = 1; x < sideLength - 1; ++x) // Вверх-низ
                Swap(
                    a,
                    new Point(x + startFrom.X, startFrom.Y),
                    new Point((sideLength + startFrom.X) - x - 1, (sideLength + startFrom.X) - 1));

            for (int x = sideLength - 1; x > 0; --x) // Вверх-право
                Swap(
                    a,
                    new Point(x + startFrom.X, startFrom.Y),
                    new Point((sideLength + startFrom.X) - 1, x + startFrom.X));

            return;
        }

        private static void Swap(int[,] data, Point a, Point b)
        {
            var temp = data[a.Y, a.X];
            data[a.Y, a.X] = data[b.Y, b.X];
            data[b.Y, b.X] = temp;
        }
    }
}
