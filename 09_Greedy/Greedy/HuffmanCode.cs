using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
	internal sealed class BinaryNode : IComparable<BinaryNode>
	{
		public int Frequency { get; set; }

		public BinaryNode ZeroPath { get; set; }

		public BinaryNode OnePath { get; set; }

		public char? Letter { get; set; }

		public int CompareTo(BinaryNode other)
		{
			return Frequency - (other?.Frequency ?? 0);
		}
	}

	public class HuffmanCode
	{
		public static long EncodeHuffman(string text)
		{
			if (string.IsNullOrEmpty(text))
				return 0L;

			Dictionary<char, int> values = new();

			foreach (var letter in text)
				if (values.ContainsKey(letter))
					values[letter] += 1;
				else
					values.Add(letter, 1);

			List<BinaryNode> q = values
				.OrderBy(x => x.Value)
				.Select(x => new BinaryNode { Letter = x.Key, Frequency = x.Value })
				.ToList();

			while(q.Count > 1)
			{
				var zero = q.First();
				q.RemoveAt(0);

				var one = q.First();
				q.RemoveAt(0);

				q.Add(new BinaryNode 
				{ 
					Frequency = zero.Frequency + one.Frequency,
					ZeroPath = zero,
					OnePath = one
				});

				q.Sort();
			}

			var head = q.First();

			string resultBits = string.Empty;
			StringBuilder builder = new();

			foreach (var letter in text)
			{
				if (head.OnePath == null)
					builder.Append(1);
				else
					SetLetter(letter, head, builder);

				resultBits += builder.ToString();
				builder.Clear();
			}

			long result = 0L;

			for (int i = 0; i < resultBits.Length; ++i)
				result |= (resultBits[i] == '0' ? 0L : 1L) << i;

			return result;
		}

		private static bool SetLetter(char letter, BinaryNode node, StringBuilder bits)
		{
			if (node.OnePath == null)
				return node.Letter == letter;

			bits.Append(0);

			if (SetLetter(letter, node.ZeroPath, bits))
				return true;

			bits.Remove(bits.Length - 1, 1);
			bits.Append(1);

			if (SetLetter(letter, node.OnePath, bits))
				return true;

			bits.Remove(bits.Length - 1, 1);

			return false;
		}
	}
}
