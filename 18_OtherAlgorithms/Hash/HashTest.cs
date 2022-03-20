using NUnit.Framework;
using System.Text;

namespace Hash
{
	public class Tests
	{
		private static readonly object[] providerEncryptTest =
		{
			new object[] {"google.com", "Skillbox", "m7s9q/ip2A/Zaz1fNhazlQ==" },
			new object[] {"Hello world!", "qwerty", "Sg0qGzKzP7o12iGAPu2wgg==" },
			new object[] {"Present", "simsalabim", "FTrzT7TEdV9zewB5a1ee4g==" }
		};

		private static readonly object[] providerDecryptTest =
		{
			new object[] { "m7s9q/ip2A/Zaz1fNhazlQ==", "Skillbox", "google.com" },
			new object[] { "Sg0qGzKzP7o12iGAPu2wgg==", "qwerty", "Hello world!" },
			new object[] { "FTrzT7TEdV9zewB5a1ee4g==", "simsalabim", "Present" }
		};

		public static string CreateMD5(string input)
		{
			// Use input string to calculate MD5 hash
			using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
			{
				byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convert the byte array to hexadecimal string
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2"));
				}
				return sb.ToString();
			}
		}

		[Test(Description = "Find strings with the same last 5 chars")]
		public void Same5lastCharsTest()
		{
			var result = Hash.Same5lastChars();
			Assert.NotNull(result);
			Assert.IsTrue(result.Length == 2);
			Assert.AreNotEqual(result[0], result[1]);

			var firstHash = CreateMD5(result[0]);
			var secondHash = CreateMD5(result[1]);

			Assert.AreEqual(firstHash.Substring(firstHash.Length - 5), secondHash.Substring(secondHash.Length - 5));
		}




		[Test(Description = "Encrypt password")]
		[TestCaseSource(nameof(providerEncryptTest))]

		public void EncryptTest(string strToEncrypt, string secret, string result)
		{
			var actual = Hash.Encrypt(strToEncrypt, secret);
			var expected = result;

			Assert.AreEqual(expected, actual);
		}


		[Test(Description = "Decrypt password")]
		[TestCaseSource(nameof(providerDecryptTest))]

		public void DecryptTest(string strToDecrypt, string secret, string result)
		{
			var actual = Hash.Decrypt(strToDecrypt, secret);
			var expected = result;

			Assert.AreEqual(expected, actual);
		}
	}
}