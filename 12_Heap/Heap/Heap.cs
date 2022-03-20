using System;
using System.Collections.Generic;
using System.Linq;
using static Heap.HeapTest;

namespace Heap
{
	public class Heap<T> where T : IComparable
	{
		private readonly List<T> data = new();

		public int Count => data.Count;

		public Heap() { }

		public Heap(IEnumerable<T> items) : this()
		{
			Add(items);
		}

		public void Add(T item)
		{
			int index = data.Count;
			data.Add(item);
			SiftUp(index);
		}

		public virtual bool Okay(T parent, T child)
		{
			return parent.CompareTo(child) < 1;
		}

		public void Add(IEnumerable<T> items)
		{
			foreach (var item in items)
				Add(item);
		}

		private void SiftUp(int index)
		{
			if (index == 0)
				return;

			int parentIndex = (index - 1) >> 1;

			if (!Okay(data[parentIndex], data[index]))
			{
				var temp = data[parentIndex];
				data[parentIndex] = data[index];
				data[index] = temp;

				SiftUp(parentIndex);
			}
		}

		public T Pop()
		{
			var result = data[0];

			int lastItemIndex = Count - 1;

			data[0] = data[lastItemIndex];
			data.RemoveAt(lastItemIndex);

			SiftDown(0);

			return result;
		}

		public T Peek()
		{
			return data[0];
		}

		private void SiftDown(int index)
		{
			int leftChildIndex = (index << 1) + 1;

			if (((index << 1) + 1) >= Count)
				return;

			int rightChildIndex = (index << 1) + 2;

			int minSon = leftChildIndex;

			if (rightChildIndex < Count && Okay(data[rightChildIndex], data[leftChildIndex]))
				minSon = rightChildIndex;

			if (!Okay(data[minSon], data[index]))
				return;

			var temp = data[index];
			data[index] = data[minSon];
			data[minSon] = temp;

			SiftDown(minSon);
		}

		public T[] ToArray()
		{
			return data.ToArray();
		}

		public List<T> ToList()
		{
			return new List<T>(data);
		}

		public static void BuildHeapFromArray(int[] checks)
		{
			var heap = new MaxHeap<int>(checks).ToArray();

			Array.Copy(heap, checks, heap.Length);
		}

		public static List<TruckCoordinate> KClosestTrucks(List<TruckCoordinate> truckCoordinateList, int k)
		{
			var result = new List<TruckCoordinate>();
			var heap = new Heap<TruckCoordinate>(truckCoordinateList);

			while (heap.Count > 0 && k-- > 0)
			{
				result.Add(heap.Pop());
			}

			return result;
		}

		public static List<long> UnloadingTruck(int n, int[] times)
		{
			if (n < 1)
				return new List<long>();

			var boxes = new Heap<int>();

			for (int i = 0; i < n; i++)
				boxes.Add(0);

			var result = new List<long>();

			foreach (var time in times)
			{
				var freeBox = boxes.Pop();
				
				result.Add(freeBox);

				freeBox += time;

				boxes.Add(freeBox);
			}

			return result;
		}
	}

	public class MaxHeap<T> : Heap<T> where T : IComparable
	{
		public MaxHeap(IEnumerable<T> items) : base(items) { }

		public override bool Okay(T parent, T child)
		{
			return parent.CompareTo(child) > -1;
		}
	}

	public class TruckCoordinate : IComparable
	{
		public int X { get; set; }
		public int Y { get; set; }

		public TruckCoordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int CompareTo(object obj)
		{
			if (obj is TruckCoordinate coordinate)
				return new TruckCoordinateComparer().Compare(this, coordinate);

			return 1;

			//if (obj is TruckCoordinate coordinate)
			//{
			//	var me = Math.Sqrt(coordinate.X * coordinate.X + coordinate.Y * coordinate.Y);
			//	var other = Math.Sqrt(coordinate.X * coordinate.X + coordinate.Y * coordinate.Y);

			//	return me.CompareTo(other);
			//}

			//return 1;
		}

		public override string ToString()
		{
			return $"X: {X}; Y: {Y}";
		}
	}
}
