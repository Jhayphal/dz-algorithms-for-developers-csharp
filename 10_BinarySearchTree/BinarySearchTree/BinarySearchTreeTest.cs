using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
	public class BinarySearchTreeTest
	{
		private static readonly object[] ReceiptData =
		{
			5, 100, 999, 1000, 9999, 10000 
		};

		[Test(Description = "Building tree")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestTreeBuilder(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, int.MaxValue), 1d)).ToList();
			var testLst = lst.OrderBy(p => p.ReceiptNumber).ToList();
			var node = BinarySearchTree.FromList(lst);
			var testNode = FromListTest(testLst);
			Assert.AreEqual(MaxDepth(testNode), MaxDepth(node));
			Assert.IsTrue(IsBST(testNode));
		}


		[Test(Description = "Building list from tree")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestListBuilder(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, int.MaxValue), 1d)).ToList();
			var testNode = FromListTest(lst);
			var listNode = BinarySearchTree.FromNode(testNode);
			Assert.AreEqual(lst.Count, listNode.Count);
			Assert.IsTrue(listNode.All(p => lst.Contains(p)));
		}


		[Test(Description = "Search for amount")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestAmountFinderBuilder(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, int.MaxValue), random.Next(0, 1000))).ToList();

			var testNode = FromListTest(lst);
			var rec = lst[random.Next(0, lst.Count - 1)];
			Assert.AreEqual(rec.Amount, BinarySearchTree.GetAmount(testNode, rec.ReceiptNumber), 0.1d);
		}


		[Test(Description = "Check tree")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestIsBst(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, 10), 1d)).ToList();
			var root = FromListTest(lst);
			Assert.IsTrue(BinarySearchTree.CheckTree(root));
			root.Right.X = new Receipt(int.MinValue, 1d);
			Assert.IsFalse(BinarySearchTree.CheckTree(root));
		}


		[Test(Description = "Delete element")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestDelete(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, int.MaxValue), 1d)).ToList();
			var root = FromListTest(lst);
			var rec = lst[random.Next(0, lst.Count - 1)];
			BinarySearchTree.Delete(root, rec);
			Assert.AreEqual(ToLs(root).Count + 1, lst.Count);
		}


		[Test(Description = "Next element")]
		[TestCaseSource(nameof(ReceiptData))]
		public void TestShort(int size)
		{
			var random = new Random();
			var lst = new int[size].Select(p => new Receipt(random.Next(1, int.MaxValue), 1d)).ToList();
			var root = FromListTest(lst);
			var rand = random.Next(0, lst.Count - 5);
			Assert.AreEqual(lst[rand + 1], BinarySearchTree.GetNext(root, lst[rand]));
			Assert.IsNull(BinarySearchTree.GetNext(root, lst[lst.Count - 1]));
		}

		private List<Receipt> ToLs(Node root)
		{
			List<Receipt> newList = new List<Receipt>();
			newList.Add(root.X);
			if (root.Left != null)
				newList.AddRange(ToLs(root.Left));
			if (root.Right != null)
				newList.AddRange(ToLs(root.Right));
			return newList;
		}

		private bool IsBST(Node root)
		{
			return IsBSTSubTree(root, int.MinValue, int.MaxValue);
		}

		private bool IsBSTSubTree(Node node, int min, int max)
		{
			if (node == null)
				return true;

			if (node.X.ReceiptNumber < min || node.X.ReceiptNumber > max)
				return false;

			return IsBSTSubTree(node.Left, min, node.X.ReceiptNumber - 1) &&
					IsBSTSubTree(node.Right, node.X.ReceiptNumber + 1, max);
		}

		private int MaxDepth(Node node)
		{
			if (node == null)
				return 0;
			else
			{
				int lDepth = MaxDepth(node.Left);
				int rDepth = MaxDepth(node.Right);

				if (lDepth > rDepth)
					return (lDepth + 1);
				else
					return (rDepth + 1);
			}
		}

		private Node FromListTest(List<Receipt> elements)
		{
			elements.Sort((a, b) => a.ReceiptNumber.CompareTo(b.ReceiptNumber));
			
			int middle = elements.Count >> 1;
			
			var result = new Node(elements[middle], null);
			
			FromArray(result, elements, 0, middle - 1);
			FromArray(result, elements, middle + 1, elements.Count - 1);

			return result;
		}

		private Node FromArray(Node root, IReadOnlyList<Receipt> items, int start, int end)
		{
			Receipt item;
			Node child;
			
			if (start == end)
			{
				item = items[start];
				child = new Node(item, root);
				
				if (item.ReceiptNumber < root.X.ReceiptNumber)
					root.Left = child;
				else
					root.Right = child;
				
				return root;
			}
			
			if (start > end)
				return root;
			
			int middle = (start + end) >> 1;
			
			item = items[middle];
			child = new Node(item, root);

			if (item.ReceiptNumber < root.X.ReceiptNumber)
				root.Left = child;
			else
				root.Right = child;
			
			FromArray(child, items, start, middle - 1);
			FromArray(child, items, middle + 1, end);

			return root;
		}
	}
}
