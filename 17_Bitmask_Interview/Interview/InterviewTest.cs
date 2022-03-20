using NUnit.Framework;
using System;

namespace Interview
{
	public class InterviewTest
	{
		private bool slowSolve1(int[] a, int S)
		{
			// Это медленное решение, вы должны придумать решение, которое работает за О(N)
			// И вообще, подсматривать решения в тестах - нехорошо :)
			for (int i = 0; i < a.Length; ++i)
			{
				int s = 0;
				for (int j = i; j < a.Length; ++j)
				{
					s += a[j];
					if (s == S)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void slowSolve2(int[,] a)
		{
			// Это медленное решение, вы должны придумать решение, которое не использует доп массив
			// И вообще, подсматривать решения в тестах - нехорошо
			int[,] b = new int[a.GetLength(0), a.GetLength(1)];
			for (int i = 0; i < a.GetLength(0); ++i)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					b[a.GetLength(0) - j - 1, i] = a[i, j];
				}
			}
			for (int i = 0; i < a.GetLength(0); ++i)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					a[i, j] = b[i, j];
				}
			}
		}

		[Test]
		public void testFindSubarray()
		{
			Random rn = new Random();
			for (int T = 0; T < 1000; ++T)
			{
				int n = rn.Next(10000) + 10;
				int[] a = new int[n];
				for (int i = 0; i < a.Length; ++i)
				{
					a[i] = rn.Next(1000) - 500;
				}
				int l = rn.Next(n);
				int r = rn.Next(n);
				if (r < l)
				{
					int t = l;
					l = r;
					r = t;
				}
				int S = 0;
				for (int i = l; i <= r; ++i)
				{
					S += a[i];
				}
				Assert.AreEqual(slowSolve1(a, S), Interview.FindSubarray(a, S));
			}
			int cnt = 0;
			for (int T = 0; T < 1000; ++T)
			{
				int n = rn.Next(10000) + 10;
				int[] a = new int[n];
				for (int i = 0; i < a.Length; ++i)
				{
					a[i] = rn.Next(1000) - 500;
				}
				int l = rn.Next(n);
				int r = rn.Next(n);
				if (r < l)
				{
					int t = l;
					l = r;
					r = t;
				}
				int S = rn.Next(20000) - 10000;
				if (!slowSolve1(a, S))
				{
					cnt += 1;
				}
				Assert.AreEqual(slowSolve1(a, S), Interview.FindSubarray(a, S));
			}
		}

		[Test]
		public void TestRotateMatrix()
		{
			Random rn = new Random();
			for (int T = 0; T < 10000; ++T)
			{
				int n = rn.Next(100) + 1;
				int[,] a = new int[n, n];
				int[,] b = new int[n, n];
				for (int i = 0; i < n; ++i)
				{
					for (int j = 0; j < n; ++j)
					{
						a[i, j] = rn.Next();
						b[i, j] = a[i, j];
					}
				}
				slowSolve2(a);
				Interview.RotateMatric(b);
				for (int i = 0; i < n; ++i)
				{
					for (int j = 0; j < n; ++j)
					{
						Assert.AreEqual(a[i, j], b[i, j]);
					}
				}

			}
		}
	}
}