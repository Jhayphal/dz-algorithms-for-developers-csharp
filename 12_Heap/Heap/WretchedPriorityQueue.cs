using System;

namespace Heap
{
	public class WretchedPriorityQueue
	{
		private Heap<int> heap = new Heap<int>();

		public int Size()
		{
			return heap.Count;
		}

		public void Add(int x)
		{
			heap.Add(x);
		}

		public int Pop()
		{
			if (IsEmpty())
				throw new Exception("The queue is empty");

			return heap.Pop();
		}

		public int Peek()
		{
			if (IsEmpty())
				throw new Exception("The queue is empty");

			return heap.Peek();
		}

		public bool IsEmpty()
		{
			return heap.Count == 0;
		}
	}
}
