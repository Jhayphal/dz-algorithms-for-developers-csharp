using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BenchmarkSorted
{
	class Program
	{
		static void Main(string[] args)
		{
			long totalUnique = 0;

			// Make it like 300-500 for faster results,
			// 1000 iterations may take ~5-10 minutes
			int totalIterations = 1000;
			double[] sizes = new double[totalIterations];
			double[] durations = new double[totalIterations];
			int size = 1000;

			Console.WriteLine($"Running {totalIterations} iterations,\r\nHang on, this will take a while...");
			for (int i = 0; i < totalIterations; i++)
			{

				long[] testArray = GenerateRandomSorted(size);
				var stopWatch = new Stopwatch();
				stopWatch.Start();
				List<long> unique = ExampleSorted.Program.FindUniqueSorted(testArray);
				stopWatch.Stop();

				sizes[i] = size;
				durations[i] = stopWatch.ElapsedMilliseconds;
				totalUnique += unique.Count;
				size += 5000;

				Console.WriteLine($"({i}/{totalIterations}) FindUniqueSorted([{size} elements]) took {durations[i]} milliseconds");
			}

			Console.WriteLine($"Min time: {durations.Min()}, Max time: {durations.Max()}, Average time: {durations.Average()}");
			Console.WriteLine($"Total unique numbers = {totalUnique}");
			Console.ReadLine();
		}

		private static long[] GenerateRandomSorted(int size)
		{
			long[] arr = new long[size];
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				arr[i] = random.Next();
			}
			Array.Sort(arr);
			return arr;
		}
	}
}
