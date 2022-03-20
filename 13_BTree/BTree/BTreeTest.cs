using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTree
{
	public class BTreeTest
	{
		[Test]
		public void BTreeTest1()
		{
			BTree bTree = new BTree();
			var tempArray = new List<int>();
			for (int i = 0; i < 1_000_000; ++i)
			{
				tempArray.Add(i * 2);
			}
			var rnd = new Random();
			var randomized = tempArray.OrderBy(item => rnd.Next());
			for (int i = 0; i < 1_000_000; ++i)
			{
				bTree.Add(tempArray[i]);
			}

			var badResult = new int[] { -10, 1, 12_381, 99_115 };
			foreach (var item in badResult)
			{
				Assert.IsFalse(bTree.Contains(item), "Node <" + item + "> found in Btree!");
			}

			var goodResult = new int[] { 0, 4, 1_230, 87_612, 1_230_000 };
			foreach (var item in goodResult)
			{
				Assert.IsTrue(bTree.Contains(item), "Node <" + item + "> NOT found in Btree!");
			}

			int[] ar = bTree.GetSorted();
			for (int i = 0; i < 1000000; ++i)
			{
				Assert.AreEqual(ar[i], i * 2);
			}

			Assert.IsTrue(bTree.GetMaxHeight() < 1000);
		}
	}
}