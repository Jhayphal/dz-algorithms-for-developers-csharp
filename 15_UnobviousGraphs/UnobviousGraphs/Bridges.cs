using System;
using System.Collections.Generic;
using System.Linq;

namespace UnobviousGraphs
{
    public class Bridges
	{
		public static bool IsProjectSuccess(Dictionary<string, List<string>> project)
		{
			if (project == null || project.Count == 0)
				return false;

			HashSet<string> islands = GetIslands(project);

			if (islands.Count < 2)
				return false;

			HashSet<Bridge> all = GetBridges(project);

			if (all.Count < 2)
				return false;

			foreach (var islandStart in islands)
			{
				HashSet<Bridge> visited = new();

				WalkRouteFromPoint(islandStart, project, visited);

				if (all.Except(visited).Count() == 0)
					return true;
			}

			return false;
		}

        private static HashSet<string> GetIslands(Dictionary<string, List<string>> project)
        {
			var islands = new HashSet<string>();

			foreach (var routes in project)
			{
				islands.Add(routes.Key);

				foreach (var nextIsland in routes.Value)
					islands.Add(nextIsland);
			}

			return islands;
		}

        private static HashSet<Bridge> GetBridges(Dictionary<string, List<string>> project)
        {
			var bridges = new HashSet<Bridge>();

			foreach (var routes in project)
				foreach (var nextIsland in routes.Value)
					bridges.Add(new Bridge(routes.Key, nextIsland));

			return bridges;
        }

		private static void WalkRouteFromPoint(
			string island, 
			Dictionary<string, List<string>> project, 
			HashSet<Bridge> visited)
        {
			var routes = project[island];

			foreach(var route in routes)
            {
				if (!visited.Add(new Bridge(island, route)))
					continue;

				WalkRouteFromPoint(route, project, visited);

				return;
            }
        }
	}

	public class Bridge : IEquatable<Bridge>
	{
		public readonly string A;

		public readonly string B;

		public Bridge(string a, string b)
        {
			this.A = a;
			this.B = b;
        }

        public override bool Equals(object? obj)
        {
			if (obj == null)
				return false;

			if (obj is Bridge bridge)
				return Equals(bridge);

            return false;
        }

        public bool Equals(Bridge? other)
        {
			if (other == null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (string.Equals(this.A, other.A) && string.Equals(B, other.B))
				return true;

			return string.Equals(this.A, other.B) && string.Equals(B, other.A);
		}

        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode();
        }

        public override string ToString()
        {
            return A + " - " + B;
        }
    }
}
