using System;
using System.Diagnostics;

namespace Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 10000000;
			int[] arr = new int[count];
			Random random = new Random();
			for (int i = 0; i < count; i++)
			{
				arr[i] = random.Next();
			}
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			Array.Sort(arr);
			stopWatch.Stop();

			Console.WriteLine($"It took {stopWatch.Elapsed.TotalSeconds} seconds to sort {count} elements");
			Console.WriteLine($"Sorted: [ {arr[0]}, {arr[1]}, ... {arr[arr.Length - 2]}, {arr[arr.Length - 1]} ]");
			Console.ReadLine();
		}
	}
}
