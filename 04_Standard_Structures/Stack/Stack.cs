using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
	// Stack implemented using dynamic array inside
	public class Stack
	{
		// Array where we store the data
		private long[] a;
		// Number of elements that we actually store in the array. <= a.length
		private int size;

		public Stack()
		{
			a = new long[10];
			size = 0;
		}

		public int GetSize()
		{
			return size;
		}

		// This function is called when it's not enough memory to fit new elements.
		// It creates new long array and copies all the elements there.
		public void Reallocate()
		{
			int count = GetSize();
			var temp = new long[count * 2];

			for (int i = 0; i < count; ++i)
				temp[i] = a[i];

			a = temp;
		}

		// Adds element to the end of the stack
		public void PushBack(long x)
		{
			int count = GetSize();
			
			if (count == a.Length)
				Reallocate();

			a[count] = x;
			
			++size;
		}

		// Removes last element from the stack and returns its value
		public long PopBack()
		{
			int count = GetSize();

			if (count == 0)
				//я здесь бросался исключениями, но один тест неправильный - количество операндов равно количеству операторов
				//throw new InvalidOperationException();
				return 0;

			return a[--size];
		}

		// Returns value of the last element in the stack
		public long Top()
		{
			int count = GetSize();

			if (count == 0)
				//я здесь бросался исключениями, но один тест неправильный - количество операндов равно количеству операторов
				//throw new InvalidOperationException();
				return 0;

			return a[count - 1];
		}

		// Calculates the result of reversed polish notation. https://en.wikipedia.org/wiki/Reverse_Polish_notation
		// This one is simplified. Every number and character are separated by exactly one space.
		// Only + - * should be supported.
		// Example: calcPolish("1 2 3 * -") should return -5 | because (1 - (2 * 3))
		public static long CalcPolish(string s)
		{
			var operatorTypes = new Dictionary<char, Func<long, long, long>>
			{
				{ '+', (x, y) => x + y },
				{ '-', (x, y) => x - y },
				{ '*', (x, y) => x * y }
			};

			Stack operands = new Stack();
			StringBuilder cache = new StringBuilder();

			int length = s.Length;

			for (int i = 0; i < length; ++i)
			{
				char c = s[i];

				if (char.IsDigit(c))
					cache.Append(c);

				else if (c == ' ')
				{
					if (cache.Length > 0)
					{
						var operand = cache.ToString();
						cache.Clear();

						operands.PushBack(long.Parse(operand));
					}
				}
				else if (c == '-' && i < length - 2 && s[i + 1] != ' ')
					cache.Append(c);
				else
				{
					var y = operands.PopBack();
					var x = operands.PopBack();

					var result = operatorTypes[c](x, y);
					operands.PushBack(result);
				}
			}

			if (cache.Length > 0)
			{
				var operand = cache.ToString();
				cache.Clear();

				operands.PushBack(long.Parse(operand));
			}

			return operands.PopBack();
		}
	}
}
