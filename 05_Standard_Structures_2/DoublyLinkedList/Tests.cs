using NUnit.Framework;
using System;

namespace DoublyLinkedList
{
	public class Tests
	{
		private static void AssertEqualsArray(int[] expected, int[] actual)
		{
			Assert.AreEqual(expected, actual, $"Extended array [{string.Join(", ", expected)}].{Environment.NewLine}  Actual array   [{string.Join(", ", actual)}]");
		}

		private static void AssertNotEqualArray(int[] expected, int[] actual)
		{
			Assert.AreNotEqual(expected, actual, $"Extended array [{string.Join(", ", expected)}].{Environment.NewLine}  Actual array   [{string.Join(", ", actual)}]");
		}

		[Test]
		public void TestToArray()
		{
			int[] t1 = { 1, 2, 5, 1, 2, 6, 1, 6, 8, 324, -10, 20 };
			int[] t2 = { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 2, 3 };
			AssertEqualsArray(t1, DoublyLinkedList.FromArray(t1).ToArray());
			AssertEqualsArray(t2, DoublyLinkedList.FromArray(t2).ToArray());
			AssertNotEqualArray(t2, DoublyLinkedList.FromArray(t1).ToArray());
		}


		[Test]
		public void TestSize()
		{
			int[] t1 = { 1, 2, 3, 4, 5, 6 };
			int[] t2 = { 1 };
			int[] t3 = new int[10000];

			Assert.AreEqual(6, DoublyLinkedList.FromArray(t1).GetSize());
			Assert.AreEqual(1, DoublyLinkedList.FromArray(t2).GetSize());
			Assert.AreEqual(10000, DoublyLinkedList.FromArray(t3).GetSize());
			Assert.AreEqual(0, new DoublyLinkedList().GetSize());
		}

		[Test]
		public void TestPushAndPop()
		{
			DoublyLinkedList dlList = new DoublyLinkedList();
			dlList.PushFront(1);
			dlList.PushFront(2);
			dlList.PushFront(3);
			dlList.PushBack(4);
			dlList.PushBack(5);
			dlList.PushBack(6);
			AssertEqualsArray(new int[] { 3, 2, 1, 4, 5, 6 }, dlList.ToArray());
			Assert.AreEqual(6, dlList.PopBack());
			Assert.AreEqual(5, dlList.PopBack());
			Assert.AreEqual(3, dlList.PopFront());
			AssertEqualsArray(new int[] { 2, 1, 4 }, dlList.ToArray());
		}

		[Test]
		public void RemoveAndInsertAfter()
		{
			var dlList = new DoublyLinkedList();
			for (int i = 0; i < 10; ++i)
			{
				dlList.PushBack(1);
			}
			for (int i = 9; i >= 0; --i)
			{
				dlList.InsertAfter(dlList.GetAt(i), i);
			}
			AssertEqualsArray(new int[] { 1, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9 }, dlList.ToArray());

			for (int i = 9; i >= 0; --i)
			{
				dlList.Remove(dlList.GetAt(2 * i));
			}
			AssertEqualsArray(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, dlList.ToArray());
			Assert.AreEqual(10, dlList.GetSize());

			for (int i = 0; i < 10; ++i)
			{
				dlList.PopBack();
			}
			Assert.AreEqual(0, dlList.GetSize());

			for (int i = 0; i < 7; ++i)
			{
				dlList.PushFront(1);
				dlList.PushBack(2);
			}
			Assert.AreEqual(14, dlList.GetSize());

			for (int i = 0; i < 14; ++i)
			{
				dlList.PopFront();
			}
			Assert.AreEqual(0, dlList.GetSize());

			dlList.PushFront(1);
			Assert.AreEqual(1, dlList.End.X);

			dlList.PopBack();
			dlList.PushBack(2);
			Assert.AreEqual(2, dlList.Begin.X);

			dlList.PopFront();
			dlList.PushBack(7);
			Assert.AreEqual(7, dlList.End.X);
		}
	}
}