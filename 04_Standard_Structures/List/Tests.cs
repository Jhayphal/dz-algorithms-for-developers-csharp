using NUnit.Framework;
using System;

namespace List
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
			AssertEqualsArray(t1, List.FromArray(t1).ToArray());
			AssertEqualsArray(t2, List.FromArray(t2).ToArray());
			AssertNotEqualArray(t2, List.FromArray(t1).ToArray());
		}

		[Test]
		public void TestSize()
		{
			int[] t1 = { 1, 2, 3, 4, 5, 6 };
			int[] t2 = { 1 };
			int[] t3 = new int[10000];

			Assert.AreEqual(6, List.FromArray(t1).GetSize());
			Assert.AreEqual(1, List.FromArray(t2).GetSize());
			Assert.AreEqual(10000, List.FromArray(t3).GetSize());
			Assert.AreEqual(0, new List().GetSize());
		}

		[Test]
		public void TestEverySecond()
		{
			int[] t1 = { 1, 2, 3, 4, 5, 6 };
			int[] a1 = { 1, 3, 5 };
			int[] t2 = { 1 };
			int[] a2 = { 1 };
			int[] t3 = { 1, 1, 1, 1 };
			int[] a3 = { 1, 1 };
			int[] t4 = { 6, 1, 6, 1, 6, 2, 5, 3, 7 };
			int[] a4 = { 6, 6, 6, 5, 7 };
			List list = List.FromArray(t1);
			List list2 = list.CopyEverySecond();
			AssertEqualsArray(a1, list2.ToArray());
			AssertEqualsArray(t1, list.ToArray());

			list = List.FromArray(t2);
			list2 = list.CopyEverySecond();
			AssertEqualsArray(a2, list2.ToArray());
			AssertEqualsArray(t2, list.ToArray());

			list = List.FromArray(t3);
			list2 = list.CopyEverySecond();
			AssertEqualsArray(a3, list2.ToArray());
			AssertEqualsArray(t3, list.ToArray());

			list = List.FromArray(t4);
			list2 = list.CopyEverySecond();
			AssertEqualsArray(a4, list2.ToArray());
			AssertEqualsArray(t4, list.ToArray());
		}

		[Test]
		public void TestFilterX()
		{
			int[] t1 = { 1, 2, 3, 4, 5, 6 };
			int[] a1 = { 1, 3, 5 };
			int[] t2 = { 1 };
			int[] a2 = { 1 };
			int[] t3 = { 12, 6, 1, 7 };
			int[] a3 = { 1, 7 };
			int[] t4 = { 8, 2, 12, 4, 120, 1240, 5, 1224, 2024 };
			int[] a4 = { 2, 5 };
			int[] t5 = new int[10000];
			List list = List.FromArray(t1);
			list.FilterDivisible(2);
			AssertEqualsArray(a1, list.ToArray());

			list = List.FromArray(t2);
			list.FilterDivisible(7);
			AssertEqualsArray(a2, list.ToArray());

			list = List.FromArray(t3);
			list.FilterDivisible(3);
			AssertEqualsArray(a3, list.ToArray());

			list = List.FromArray(t4);
			list.FilterDivisible(4);
			AssertEqualsArray(a4, list.ToArray());

			list = List.FromArray(t5);
			list.FilterDivisible(7);
			Assert.AreEqual(0, list.GetSize());
		}

		[Test]
		public void TestGetAndInsert()
		{
			var list = new List();
			list.PushFront(4);
			list.PushFront(3);
			list.PushFront(1);
			list.InsertAfter(list.GetAt(0), 2);
			list.InsertAfter(list.GetAt(3), 5);
			var n = list.GetAt(2);
			for (int i = 0; i < 5; ++i)
			{
				list.InsertAfter(n, 100);
			}
			int[] ans = { 1, 2, 3, 100, 100, 100, 100, 100, 4, 5 };
			AssertEqualsArray(ans, list.ToArray());
			list = new List();
			for (int i = 0; i < 5; ++i)
			{
				list.PushFront(0);
				list.InsertAfter(list.GetAt(0), 1);
			}
			int[] ans2 = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
			AssertEqualsArray(ans2, list.ToArray());
		}
	}
}
