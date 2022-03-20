using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UnobviousGraphs
{
    public class Path
	{
		public static int ShortestPathDuration(int[,] map)
		{
			Point goal = new (map.GetLength(0) - 1, map.GetLength(1) - 1);

			HashSet<Point> closed = new();
			
			PriorityQueue<List<Point>, int> open = new();
			
			open.Enqueue(
				new List<Point> { 
					new Point(0, 0) }, 0);

			while (open.Count > 0)
            {
				var path = open.Dequeue();
				var current = path.Last();

				if (closed.Contains(current))
					continue;

				if (current == goal)
					return ComputePathCost(map, path);

				closed.Add(current);

				foreach (var successor in GetSuccessors(current, map))
				{
                    var newPath = new List<Point>(path)
                    {
                        successor
                    };

					var priority = ComputePathCost(map, newPath);

					open.Enqueue(newPath, priority);
				}
			}

			return -1;
		}

		private static int ComputePathCost(int[,] map, List<Point> path)
        {
			var result = 0;

			foreach (var point in path)
				result += map[point.X, point.Y];

			return result;
        }

		private static IEnumerable<Point> GetSuccessors(Point point, int[,] map)
        {
			if (point.X + 1 < map.GetLength(0))
				yield return new Point(point.X + 1, point.Y);

			if (point.Y + 1 < map.GetLength(1))
				yield return new Point(point.X, point.Y + 1);
		}
	}
}
