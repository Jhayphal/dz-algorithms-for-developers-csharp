using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BinarySearchTree
{
	public static class BinarySearchTree
	{
		public static Node FromList(List<Receipt> elements)
		{
			if ((elements?.Count ?? 0) == 0)
				return null;
			
			elements.Sort((a, b) => a.ReceiptNumber.CompareTo(b.ReceiptNumber));

			int middle = elements.Count >> 1;

			var node = new Node(elements[middle], parent: null);

			SetChildren(node, elements, 0, middle - 1);
			SetChildren(node, elements, middle + 1, elements.Count - 1);

			return node;
		}

		private static void SetChildren(Node main, IReadOnlyList<Receipt> items, int start, int end)
		{
			Receipt item;
			Node child;
			
			if (start == end)
			{
				item = items[start];
				child = new Node(item, main);
				
				if (item.ReceiptNumber < main.X.ReceiptNumber)
					main.Left = child;
				else
					main.Right = child;
				
				return;
			}
			
			if (start > end)
				return;
			
			int middle = (start + end) >> 1;
			
			item = items[middle];
			child = new Node(item, main);

			if (item.ReceiptNumber < main.X.ReceiptNumber)
				main.Left = child;
			else
				main.Right = child;
			
			SetChildren(child, items, start, middle - 1);
			SetChildren(child, items, middle + 1, end);
		}

		public static List<Receipt> FromNode(Node root)
		{
			var result = new List<Receipt> {root.X};
			
			Expand(root.Left, result);
			Expand(root.Right, result);

			return result;
		}

		private static void Expand(Node root, List<Receipt> items)
		{
			if (root == null)
				return;

			items.Add(root.X);
			
			Expand(root.Left, items);
			Expand(root.Right, items);
		}

		public static double GetAmount(Node root, int receiptNumber)
		{
			if (root == null)
				return 0d;
			
			if (root.X.ReceiptNumber == receiptNumber)
				return root.X.Amount;

			return GetAmount(root.Left, receiptNumber) + GetAmount(root.Right, receiptNumber);
		}

		public static bool CheckTree(Node root, int? left = null, int? right = null)
		{
			if (root == null)
				return true;

			if (left.HasValue && root.X.ReceiptNumber < left)
				return false;
			
			if (right.HasValue && root.X.ReceiptNumber > right)
				return false;

			return CheckTree(root.Left, left, root.X.ReceiptNumber)
			       && CheckTree(root.Right, root.X.ReceiptNumber, right);
		}

		public static void Delete(Node root, Receipt receipt)
		{
			if (root == null)
				return;

			if (!ReferenceEquals(root.X, receipt))
			{
				Delete(root.Left, receipt);
				Delete(root.Right, receipt);
				
				return;
			}
			
			if (root.Left == null && root.Right == null)
			{
				var parent = root.Parent;

				if (ReferenceEquals(root, parent.Left))
					parent.Left = null;
				else
					parent.Right = null;
			}
			else if (root.Left != null && root.Right != null)
			{
				var currentNode = root.Right;

				while (currentNode.Left != null)
					currentNode = currentNode.Left;

				root.X = currentNode.X;
				
				Delete(currentNode, currentNode.X);
			}
			else
			{
				var parent = root.Parent;

				if (ReferenceEquals(root, parent.Left))
					parent.Left = root.Left ?? root.Right;
				else
					parent.Right = root.Left ?? root.Right;
			}
		}

		public static Receipt GetNext(Node root, Receipt receipt)
		{
			root = Find(root, receipt);
			
			if (root == null)
				return null;

			if (root.Right != null)
			{
				var next = root.Right;
				
				while (next.Left != null)
					next = next.Left;

				return next.X;
			}

			var result = root;
			
			while (result?.Parent?.Right == result)
				result = result?.Parent;

			return result?.Parent?.X;
		}

		private static Node Find(Node root, Receipt receipt)
		{
			if (root == null)
				return null;

			if (ReferenceEquals(root.X, receipt))
				return root;

			return Find(root.Left, receipt) ?? Find(root.Right, receipt);
		}
	}
}
