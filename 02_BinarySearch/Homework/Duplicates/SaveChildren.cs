using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duplicates
{
	public class SaveChildren
	{
		public static void PermutateWords(char[][] words)
		{
			while (TryFindDuplicates(words, out var indexes))
				foreach (int index in indexes)
					ChildShiftAlgorithm(words[index]);
		}

		private static bool TryFindDuplicates(char[][] words, out int[] indexes)
		{
			indexes = null;

			if ((words?.Length ?? 0) == 0)
				return false;

			indexes = new int[words.Length];
			int nextIndexInIndexes = 0;

			bool found = false;

			for (int i = 0; i < words.Length; ++i)
				for (int j = i + 1; j < words.Length; ++j)
					if (AreEquals(words[i], words[j]))
					{
						indexes[nextIndexInIndexes++] = i;
						found = true;
						break;
					}

			Array.Resize(ref indexes, nextIndexInIndexes);

			return found;
		}

		private static bool AreEquals(char[] word1, char[] word2)
		{
			int length = word1?.Length ?? 0;

			if (length != (word2?.Length ?? 0))
				return false;

			for (int i = 0; i < length; ++i)
				if (word1[i] != word2[i])
					return false;

			return true;
		}

		private static void ChildShiftAlgorithm(char[] word)
		{
			char first = word[0];

			for (int i = 1; i < word.Length - 1; ++i)
				word[i - 1] = word[i];

			word[word.Length - 1] = first;
		}
	}
}
