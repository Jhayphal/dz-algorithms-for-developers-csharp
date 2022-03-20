using System;
using System.Collections.Generic;

namespace List
{
	public class Node
	{
		public int X { get; set; }
		public Node Next { get; set; }

		public Node(int x)
		{
			X = x;
			Next = null;
		}
	}

	public class List
	{
		// Pointer to the beginning of the list
		public Node Begin { get; set; }

		// Adds element to the beginning of the list
		public void PushFront(int x)
		{
			var first = new Node(x)
			{
				Next = Begin
			};

			Begin = first;
		}

		public List()
		{
			Begin = null;
		}

		// This function could be useful for debugging and testing.
		public void Print()
		{
			Node n = Begin;
			while (n != null)
			{
				Console.Write(n.X + " ");
				n = n.Next;
			}
			Console.WriteLine();
		}

		// This function should return copy of the list where every second element is removed. Initial list should not be changed.
		// E.g. if we run copyEverySecond on list [1, 2, 3, 4, 5, 6, 7, 100, 120, 162, 0, 1] new list with values [1, 3, 5, 7, 120, 0] should be returned.
		public List CopyEverySecond()
		{
			var result = new List();

			var currentItem = Begin;

			if (currentItem == null)
				return result;

			int currentIndex = 0;

			var resultCurrentItem = result.Begin = new Node(currentItem.X);

			currentItem = currentItem.Next;
			++currentIndex;

			while (currentItem != null)
			{
				if ((currentIndex & 1) == 0)
				{
					resultCurrentItem.Next = new Node(currentItem.X);

					resultCurrentItem = resultCurrentItem.Next;
				}

				currentItem = currentItem.Next;
				++currentIndex;
			}

			return result;
		}

		IEnumerable<Node> Nodes()
		{
			var current = Begin;

			if (current != null)
			{
				do
				{
					yield return current;

					current = current.Next;
				}
				while (current != null);
			}
		}

		// Returns number of elements in list
		public int GetSize()
		{
			int count = 0;

			foreach (var item in Nodes())
				++count;

			return count;
		}

		// This function converts our list to an array. New array is created with values the same as in list.
		public int[] ToArray()
		{
			int count = GetSize();
			var result = new int[count];

			int index = 0;

			foreach (var item in Nodes())
				result[index++] = item.X;

			return result;
		}

		// This function removes elements x.next from the list
		// O(1) time is expected
		public void RemoveAfter(Node x)
		{
			x.Next = null;
		}

		// This function inserts new element with value val right after the element x.
		// O(1) time is expected
		public void InsertAfter(Node x, int val)
		{
			var next = x.Next;

			x.Next = new Node(val)
			{
				Next = next
			};
		}

		// This function removes all elements from the list that are divisible by x.
		// E.g. list {1, 2, 3, 4, 4, 10, 7}  after filterDivisible(2) would look like {1, 3, 7}.
		// O(N) time is expected.
		public void FilterDivisible(int x)
		{
			Node tail = null;
			Node current = Begin;

			while(current != null)
			{
				if (current.X % x == 0)
				{
					if (tail == null)
						Begin = current.Next;
					else
						tail.Next = current.Next;
				}
				else
					tail = current;
				
				current = current.Next;
			}
		}

		// This function returns Node from the list by index. O(N) time is expected.
		public Node GetAt(int index)
		{
			int currentIndex = 0;

			foreach (var item in Nodes())
				if (currentIndex++ == index)
					return item;

			throw new ArgumentOutOfRangeException(nameof(index));
		}

		// This function creates List from an array
		public static List FromArray(int[] a)
		{
			var list = new List();
			for (int i = a.Length - 1; i >= 0; --i)
			{
				list.PushFront(a[i]);
			}
			return list;
		}

	}
}
