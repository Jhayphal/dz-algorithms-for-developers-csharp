using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
	public class WretchedPriorityQueueTest
	{
		const int SIZE = 500;
		[Test]
		public void SizeTest()
		{
			var queue = new WretchedPriorityQueue();
			Assert.AreEqual(0, queue.Size());
			queue.Add(1);
			Assert.AreEqual(1, queue.Size());
			queue.Pop();
			Assert.AreEqual(0, queue.Size());
		}

		[Test]
		public void IsEmptyTest()
		{
			var queue = new WretchedPriorityQueue();
			Assert.IsTrue(queue.IsEmpty());
			queue.Add(1);
			Assert.IsFalse(queue.IsEmpty());
			queue.Pop();
			Assert.IsTrue(queue.IsEmpty());
		}

		[Test]
		public void PeekTest()
		{
			var queue = new WretchedPriorityQueue();
			for (var i = 1; i <= SIZE; ++i)
			{
				queue.Add(i);
			}

			for (var i = SIZE; i > 0; --i)
			{
				Assert.AreEqual(SIZE - i + 1, queue.Peek());
				Assert.AreEqual(SIZE - i + 1, queue.Pop());
			}

			Assert.Throws<Exception>(() => queue.Peek());
		}

		[Test]
		public void PopTest()
		{
			PriorityQueue<int, int> ints = new PriorityQueue<int, int>();
			var queue = new WretchedPriorityQueue();

			var arrays = Enumerable.Range(int.MinValue, 1000).Distinct().Take(100);
			foreach (var x in arrays)
			{
				ints.Enqueue(x, x);
				queue.Add(x);
			}


			while (ints.Count > 0)
			{
				Assert.AreEqual(ints.Dequeue(), queue.Pop());
			}

			Assert.Throws<Exception>(() => queue.Peek());
		}

		[Test]
		public void TimeTest()
		{
			PriorityQueue<int, int> ints = new PriorityQueue<int, int>();
			var queue = new WretchedPriorityQueue();
			var arrays = Enumerable.Range(int.MinValue, 1000000).Distinct().Take(100000);

			var standartStopWatcher = new Stopwatch();
			standartStopWatcher.Start();

			foreach (var k in arrays)
			{
				ints.Enqueue(k, k);
			}
			while (ints.Count > 0)
			{
				ints.Dequeue();
			}
			standartStopWatcher.Stop();



			var customStopWatcher = new Stopwatch();
			customStopWatcher.Start();
			foreach (var j in arrays)
			{
				queue.Add(j);
			}
			while (ints.Count > 0)
			{
				queue.Pop();
			}
			customStopWatcher.Stop();

			var timeDifference = customStopWatcher.ElapsedMilliseconds / standartStopWatcher.ElapsedMilliseconds;

			Assert.IsTrue(timeDifference < 10, "Очередь работает слишком долго");
		}
	}
}
