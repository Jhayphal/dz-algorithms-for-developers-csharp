using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
	public class Node
	{
		public Receipt X;
		public Node Left;
		public Node Right;
		public Node Parent;

		public Node(Receipt x, Node parent)
		{
			X = x;
			Parent = parent;
		}


		public string ToString()
		{
			return "Node{x=" + X +'}';
		}
	}
}
