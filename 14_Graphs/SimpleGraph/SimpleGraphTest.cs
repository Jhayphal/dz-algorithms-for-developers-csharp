using NUnit.Framework;
using System.Collections.Generic;

namespace SimpleGraph
{
	public class Tests
	{
		static string BFS(Node start)
		{
			HashSet<Node> seen = new HashSet<Node>();
			Queue<Node> queue = new Queue<Node>();
			string result = "";

			seen.Add(start);
			queue.Enqueue(start);

			while (queue.Count > 0)
			{
				var current = queue.Dequeue();
				if (current != null)
				{
					result += current.val;

					var i = current.neighbors.GetEnumerator();
					while (i.MoveNext())
					{
						if (!seen.Contains(i.Current))
						{
							seen.Add(i.Current);
							queue.Enqueue(i.Current);
						}
					}
				}
			}
			return result;
		}



		static readonly Employee emp1 = new Employee(1, 5, new List<int>() { 2, 3 });
		static readonly Employee emp2 = new Employee(2, 3, new List<int>());
		static readonly Employee emp3 = new Employee(3, 3, new List<int>());
		static readonly Employee emp4 = new Employee(4, 15, new List<int>() { 5 });
		static readonly Employee emp5 = new Employee(5, 10, new List<int>() { 6 });
		static readonly Employee emp6 = new Employee(6, 5, new List<int>());

		private static readonly object[] providerGetImportanceTest =
		{
			new object[] {new List<Employee>(){emp1, emp2, emp3 }, 1, 11 },
			new object[] {new List<Employee>{emp4, emp5, emp6 }, 4, 30 }
		};


		public Node GetNode(int i)
		{
			var ak1 = new Node("Ivan");
			var ak2 = new Node("Maria");
			var ak3 = new Node("Kate");
			var ak4 = new Node("Peter");
			var ak5 = new Node("Anna");
			var ak6 = new Node("Emma");
			ak1.neighbors = new List<Node>() { ak2, ak3 };
			ak2.neighbors = new List<Node> { ak1, ak4 };
			ak3.neighbors = new List<Node> { ak1, ak4 };
			ak4.neighbors = new List<Node> { ak2, ak3, ak5, ak6 };
			ak5.neighbors = new List<Node> { ak4 };
			ak6.neighbors = new List<Node> { ak4 };

			var result = new List<Node> { ak1, ak2, ak3, ak4, ak5, ak6 };
			return result[i];
		}


		private static readonly object[] providerGraphTest = { 0, 1, 2, 3, 4, 5 };


		[Test(Description = "Get importance of employee")]
		[TestCaseSource(nameof(providerGetImportanceTest))]
		public void GetImportanceTest(List<Employee> employees, int id, int importance)
		{
			var actual = SimpleGraph.GetImportance(employees, id);
			var expected = importance;

			Assert.AreEqual(expected, actual);
		}


		[Test(Description = "Help Ivan copy VK Graph")]
		[TestCaseSource(nameof(providerGraphTest))]
		public void CloneGraphVKTest(int nodeIndex)
		{
			var node = GetNode(nodeIndex);
			var actual = BFS(SimpleGraph.CloneGraphVK(node));
			var expected = BFS(node);

			Assert.AreEqual(expected, actual);
		}
	}
}