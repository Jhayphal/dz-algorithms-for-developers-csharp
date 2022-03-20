using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
	public class Virus { }

	public class Node
	{
		public Virus Virus {  get; set; }
		public List<Node> V {  get; set; }

		public Node()
		{
			Virus = new Virus();
			V = new List<Node>();
		}

		public Node(Virus virus)
		{
			Virus = virus;
			V = new List<Node>();
		}
	}

	public class Tree
	{
		public static int FromList(Node root)
		{
			if (root == null)
				return 0;

			if (root.V.Count == 0)
				return 1;

			int max = 0;

			foreach (var node in root.V)
			{
				var depth = FromList(node);

				if (depth > max)
					max = depth;
			}

			return max + 1;
		}

		public static TestNode FromList(int[] index, Virus[] elements)
		{
			var rootIndex = index
				.Select((x, i) => x == -1 ? i : 0)
				.Sum();

			var root = new TestNode(0) { Virus = elements[rootIndex] };

			int depth = 0;
			var children = index
				.Select((x, i) => x == depth 
					? new TestNode(depth + 1) { Virus = elements[i], Parent = root } 
					: null)
				.Where(x => x != null);

			while(children.Count() > 0)
			{
				root.V.AddRange(children);

				root = (TestNode)root.V[0];

				++depth;

				children = index
					.Select((x, i) => x == depth 
						? new TestNode(depth + 1) { Virus = elements[i], Parent = root } 
						: null)
					.Where(x => x != null);
			}

			while (root?.Parent != null)
				root = root.Parent;

			return root;
		}

		public static List<Node> AllOnCurrDepth(Node root, int generation, int current = 1)
		{
			if (generation == current)
				return root.V;

			var result = new List<Node>();

			foreach (var node in root.V)
			{
				var x = AllOnCurrDepth(node, generation, current + 1);

				if (x.Count > 0)
					result.AddRange(x);
			}

			return result;
		}

		public static Node Lca(TestNode first, TestNode second)
		{
			while (first?.CurrentDepth > second?.CurrentDepth)
				first = first?.Parent;

			while (first?.CurrentDepth < second?.CurrentDepth)
				second = second?.Parent;

			while(first != second)
			{
				first = first?.Parent;
				second = second?.Parent;
			}

			return first;
		}
	}
}
