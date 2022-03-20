using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			int totalUnique = 0;

			// Make it like 30-50 for faster results,
			// 100 iterations may take ~5-10 minutes
			int totalIterations = 100;
			double[] sizes = new double[totalIterations];
			double[] durations = new double[totalIterations];
			int size = 100;

			Console.WriteLine($"Running {totalIterations} iterations,\r\nHang on, this will take a while...");
			for (int i = 0; i < totalIterations; i++)
			{

				long[] testArray = GenerateRandom(size);
				var stopWatch = new Stopwatch();
				stopWatch.Start();
				List<long> unique = Example.Program.FindUnique(testArray);
				stopWatch.Stop();


				sizes[i] = size;
				durations[i] = stopWatch.ElapsedMilliseconds;
				totalUnique += unique.Count;
				size += 1000;

				Console.WriteLine($"({i}/{totalIterations}) findUnique([{size} elements]) took {durations[i]} milliseconds");
			}

			Console.WriteLine($"Min time: {durations.Min()}, Max time: {durations.Max()}, Average time: {durations.Average()}");
			Console.WriteLine($"Total unique numbers = {totalUnique}");
			Console.ReadLine();
		}

		private static long[] GenerateRandom(int size)
		{
			long[] arr = new long[size];
			Random random = new Random();
			for (int i = 0; i < size; i++)
			{
				arr[i] = random.Next();
			}
			return arr;
		}
	}
}
