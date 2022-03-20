using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greedy
{
	public class HuffmanCodeTest
	{
		private static readonly object[] Strings =
		{
			new object[] {"", 0L },
			new object[] {"a", 1L },
			new object[] {"aa", 3L },
			new object[] {"b", 1L },
			new object[] {"aba", 5L },
			new object[] {"aaa", 7L },
			new object[] {"Skillbox", 3907698L },
			new object[] {"abcdefg", 244338L }
		};

		[Test(Description = "Huffman encode")]
		[TestCaseSource(nameof(Strings))]
		public void EncodeHuffmanTest(string str, long encodeHuffman)
		{
			Assert.AreEqual(encodeHuffman, HuffmanCode.EncodeHuffman(str));
		}
	}
}
