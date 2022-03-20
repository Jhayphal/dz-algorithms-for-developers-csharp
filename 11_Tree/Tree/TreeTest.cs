using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
	public class TreeTest
	{
		[Test(Description = "Tree depth")]
		public void TestDepth()
		{
			Assert.AreEqual(0, Tree.FromList(null));
			Assert.AreEqual(1, Tree.FromList(new TestNode(0)));

			var node = TreeCreator(10, 5, new HashSet<TestNode>());
			Assert.AreEqual(MaxDepth(node), Tree.FromList(node));

			node = TreeCreator(10, 10, new HashSet<TestNode>());
			Assert.AreEqual(MaxDepth(node), Tree.FromList(node));

			node = TreeCreator(10, 8, new HashSet<TestNode>());
			Assert.AreEqual(MaxDepth(node), Tree.FromList(node));
		}

		private static readonly object[] DepthMap =
		{
			5, 6, 7, 8, 9
		};

		[Test(Description = "Tree build")]
		[TestCaseSource(nameof(DepthMap))]
		public void BuildTree(int minDepth)
		{
			var set = new HashSet<TestNode>();
			var testNode = TreeCreator(10, minDepth, set);
			var depth = MaxDepth(testNode);
			var list = set.ToList();
			for (int i = 0; i < set.Count; i++)
			{
				list[i].Id = i;
			}
			int[] links = new int[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Parent == null)
					links[i] = -1;
				else
					links[i] = list[i].Parent.Id;
			}
			var arr = list.Select(p => p.Virus).ToArray();

			var myTree = Tree.FromList(links, arr);
			var actual = MaxDepth(myTree);

			Assert.AreEqual(depth, actual);
		}


		[Test(Description = "Tree depth")]
		[TestCaseSource(nameof(DepthMap))]
		public void CurrentDepth(int minDepth)
		{
			var set = new HashSet<TestNode>();
			var testNode = TreeCreator(10, minDepth, set);
			var currDepth = set.Where(p => p.CurrentDepth == minDepth - 1).ToHashSet();
			
			var userLst = Tree.AllOnCurrDepth(testNode, minDepth - 1);
			Assert.IsNotNull(userLst);
			Assert.IsTrue(currDepth.All(p => userLst.Contains(p)));
			Assert.IsTrue(userLst.All(p => currDepth.Contains(p)));
		}

		[Test(Description = "LCA")]
		[TestCaseSource(nameof(DepthMap))]
		public void LcaTest(int minDepth)
		{
			var set = new HashSet<TestNode>();
			var testNode = TreeCreator(10, minDepth, set);
			var list = set.ToList();
			var first = list[0];
			var second = list[list.Count - 1];

			var firstParents = new List<TestNode>();
			TestNode node = first;
			while (true)
			{
				firstParents.Add(node);
				if (node.Parent == null) break;
				node = node.Parent;
			}

			var secondParents = new List<TestNode>();
			node = second;
			while (true)
			{
				secondParents.Add(node);
				if (node.Parent == null) break;
				node = node.Parent;
			}

			var commonsParens = firstParents.FindAll(p => secondParents.Contains(p));
			var minDepthOnCommonsParens = commonsParens.Min(p => p.CurrentDepth);
			var ans = commonsParens.Find(p => p.CurrentDepth == minDepthOnCommonsParens);
			Assert.AreEqual(ans, Tree.Lca(first, second));
		}

		private TestNode TreeCreator(int maxChild, int maxDepth, ISet<TestNode> set)
		{
			TestNode testNode = new TestNode(0);
			set.Add(testNode);
			TreeGen(testNode, maxChild, maxDepth, 1, set);
			return testNode;
		}

		private void TreeGen(TestNode root, int maxChild, int maxDepth, int currentDepth, ISet<TestNode> set)
		{
			if (currentDepth == maxDepth)
				return;
			int child = new Random().Next(0, maxChild);
			TestNode testNode = new TestNode(currentDepth);
			root.V.Add(testNode);
			testNode.Parent = root;
			set.Add(testNode);
			currentDepth++;
			for (int i = 0; i < child; i++)
			{
				TreeGen(testNode, maxChild, maxDepth, currentDepth, set);
			}
		}

		private int MaxDepth(Node node)
		{
			if (node == null)
				return 0;
			else
			{
				List<int> depths = new();

				node.V.ForEach(p => depths.Add(MaxDepth(p)));
				
				if (depths.Count == 0)
					return 1;
				
				return depths.Max() + 1;
			}
		}
	}

	public class TestNode : Node
	{
		public int Id { get; set; }
		public TestNode Parent { get; set; }
		public int CurrentDepth { get; set; }

		public TestNode(int currentDepth)
		{
			CurrentDepth = currentDepth;
			Virus = new Virus();
			V = new List<Node>();
		}
	}
}
