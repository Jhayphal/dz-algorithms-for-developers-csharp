using System.Collections.Generic;
using System.Linq;

namespace SimpleGraph
{
	public class SimpleGraph
	{

		// Task #1
		public static int GetImportance(List<Employee> employees, int id)
		{
			if ((employees?.Count ?? 0) == 0)
				return 0;

			var current = employees.FirstOrDefault(x => x.id == id);

			if ((current?.subordinates?.Count ?? 0) == 0)
				return current?.importance ?? 0;

			var subordinates = current
				.subordinates
				.Select(x => employees.FirstOrDefault(employee => employee.id == x))
				.Where(x => x != null)
				.ToList();

            return current.importance + subordinates
                .Sum(x => GetImportance(employees, x.id));
        }

		// Task #2
		public static Node CloneGraphVK(Node node)
		{
			List<(Node, Node)> visited = new();

			return CloneNode(node, visited);
		}

		private static Node CloneNode(Node node, List<(Node original, Node copy)> visited)
        {
			var exist = visited.FirstOrDefault(x => ReferenceEquals(node, x.original));

			if (exist.copy != null)
				return exist.copy;

			var result = new Node(node.val);

			visited.Add((node, result));

			foreach (var item in node.neighbors)
				result.neighbors.Add(CloneNode(item, visited));

			return result;
		}
	}

	// Определение сотрудника.
	public class Employee
	{
		public int id;
		public int importance;
		public List<int> subordinates;

		public Employee(int id, int importance, List<int> subordinates)
		{
			this.id = id;
			this.importance = importance;
			this.subordinates = subordinates;
		}
	};

	// Определение Node.
	public class Node
	{
		public string val;
		public List<Node> neighbors;
		public Node()
		{
			val = "";
			neighbors = new List<Node>();
		}
		public Node(string _val)
		{
			val = _val;
			neighbors = new List<Node>();
		}
		public Node(string _val, List<Node> _neighbors)
		{
			val = _val;
			neighbors = _neighbors;
		}
	}
}
