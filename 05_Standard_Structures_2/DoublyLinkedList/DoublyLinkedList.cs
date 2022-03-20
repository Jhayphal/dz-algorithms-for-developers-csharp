using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
	public class DoublyLinkedList
	{
		// You should store pointer to the first element of the list here
		public Node Begin { get; set; }
		// You should store pointer to the last element of the list here
		public Node End { get; set; }

		// This function should add new element with value x to the front of the list
		public void PushFront(int x)
		{
			var start = new Node(x)
			{
				Prev = null,
				Next = Begin
			};

			if (Begin == null)
				End = start;

			Begin = start;
		}

		// This function should add new element with value x to the end of the list
		public void PushBack(int x)
		{
			if (End == null)
			{
				PushFront(x);

				End = Begin;

				return;
			}

			End.Next = new Node(x)
			{
				Prev = End
			};

			End = End.Next;
		}

		public DoublyLinkedList()
		{
			Begin = null;
			End = null;
		}

		// This function could be useful for debug purposes
		public void Print()
		{
			Node node = this.Begin;
			while (node != null)
			{
				Console.WriteLine(node.X + " ");
				node = node.Next;
			}
			Console.WriteLine();
		}

		private IEnumerable<Node> GetNodes()
		{
			var current = Begin;

			while(current != null)
			{
				yield return current;

				current = current.Next;
			}
		}

		// This function should return the number of element in the list
		public int GetSize()
		{
			int count = 0;

			foreach (var _ in GetNodes())
				++count;

			return count;
		}

		// This function should return an array with values the same as in list
		public int[] ToArray()
		{
			var result = new int[GetSize()];
			int current = 0;

			foreach (var node in GetNodes())
				result[current++] = node.X;

			return result;
		}


		// This function should remove the element x from the list
		public void Remove(Node x)
		{
			if (x == null)
				return;

			var prev = x.Prev;
			var next = x.Next;

			if (next != null)
				next.Prev = prev;

			x.Prev = null;
			x.Next = null;

			if (x == Begin)
				Begin = next;

			if (prev != null)
				prev.Next = next;

			if (x == End)
				End = prev;
		}

		// This function should remove first element in the list and return its value
		public int PopFront()
		{
			int result = Begin?.X ?? -1;

			Remove(Begin);

			return result;
		}

		// This function should remove last element in the list and return its value
		public int PopBack()
		{
			int result = End?.X ?? -1;

			Remove(End);

			return result;
		}

		// This function should insert element with the value val after the element x
		public void InsertAfter(Node x, int val)
		{
			if (x == null)
			{
				PushFront(val);

				return;
			}

			var node = new Node(val)
			{
				Prev = x,
				Next = x.Next
			};

			if (x.Next != null)
				x.Next.Prev = node;

			x.Next = node;

			if (End == x)
				End = node;
		}

		// This function should return element at index
		public Node GetAt(int index)
		{
			int current = 0;

			foreach (var node in GetNodes())
				if (current++ == index)
					return node;

			return null;
		}

		// This function construct list from the array
		public static DoublyLinkedList FromArray(int[] a)
		{
			var dlList = new DoublyLinkedList();
			for (int i = 0; i < a.Length; ++i)
			{
				dlList.PushBack(a[i]);
			}
			return dlList;
		}
	}
}
