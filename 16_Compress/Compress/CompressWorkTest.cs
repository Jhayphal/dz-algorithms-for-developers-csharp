using NUnit.Framework;

namespace Compress
{
    public class Tests
	{
		private static readonly object[] providerCompressTest =
		{
			new object[] {"aaaabbbc", "a4b3c1" },
			new object[] {"a", "a1" },
			new object[] {"", "" },
			new object[] {"asdfggh", "a1s1d1f1g2h1" }
		};

		private static readonly object[] providerRemoveCommentsTest =
		{
			new object[]
			{
				new  string[]
				{
					"/*Test program */",
					"public static void main(String[] args) {",
					"  // variable declaration ",
					"int b = 2;",
					"int c = 3;",
					"/* This is a test",
					"   multiline  ",
					"   comment for ",
					"   testing input */",
					"System.out.println(b + c);",
					"}"
				},

				new string[]
				{
					"public static void main(String[] args) {",
					"int b = 2;",
					"int c = 3;",
					"System.out.println(b + c);",
					"}"
				}
			}
		};


		[Test(Description = "Compress graduated work")]
		[TestCaseSource(nameof(providerCompressTest))]
		public void CompressTest(string graduatedWork, string compressedGraduatedWork)
		{
			var actual = CompressWork.Compress(graduatedWork);
			var expected = compressedGraduatedWork;

			Assert.AreEqual(expected, actual);
		}


		[Test(Description = "Compress graduated work")]
		[TestCaseSource(nameof(providerCompressTest))]
		public void DecompressTest(string decompressedGraduatedWork, string graduatedWork)
		{
			var actual = CompressWork.Decompress(graduatedWork);
			var expected = decompressedGraduatedWork;

			Assert.AreEqual(expected, actual);
		}


		[Test(Description = "Delete comments from work")]
		[TestCaseSource(nameof(providerRemoveCommentsTest))]
		public void RemoveCommentsTest(string[] source, string[] expected)
		{
			var actual = CompressWork.RemoveComments(source);
			Assert.AreEqual(expected, actual);
		}
	}
}