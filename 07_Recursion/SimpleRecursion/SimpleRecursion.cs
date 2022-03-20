
namespace SimpleRecursion
{
	public class SimpleRecursion
	{
		// Task #1
		public static int FindRecursionFibonacci(int n)
		{
			if (n == 0)
				return 0;

			if (n == 1)
				return 1;

			return FindRecursionFibonacci(n - 1) + FindRecursionFibonacci(n - 2);
		}
	}
}
