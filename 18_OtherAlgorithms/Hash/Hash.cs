using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Hash
{
	public static class Hash
	{
		public static string[] Same5lastChars()
		{
			var result = new string[2];

			using (var md5 = MD5.Create())
            {
				result[0] = "a";

				string hash = GetHash(md5, result[0]);
				string hashEnd = hash.Substring(hash.Length - 5);

				var stopAtLevel = 0;

				while(stopAtLevel <= 10)
                {
					foreach(var next in GenerateStrings(stopAtLevel))
                    {
						if (string.Equals(result[0], next))
							continue;

						var nextHash = GetHash(md5, next);
						
						if (nextHash.EndsWith(hashEnd))
                        {
							result[1] = next;

							return result;
                        }
                    }

					++stopAtLevel;
                }
            }

			return result;
		}

		private static IEnumerable<string> GenerateStrings(int stopAtLevel, int level = 0)
        {
			if (stopAtLevel < level)
				yield break;

			for (char c = 'a'; c <= 'z'; ++c)
			{
				yield return c.ToString();

				foreach(var next in GenerateStrings(stopAtLevel, level + 1))
					yield return $"{c}{next}";
			}
		}

		private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
			var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

			var builder = new StringBuilder();

			for (int i = 0; i < data.Length; ++i)
				builder.Append(data[i].ToString("x2"));

			return builder.ToString();
        }

		public static string Encrypt(string strToEncrypt, string secret)
		{
			using(var aes = Aes.Create())
            {
				aes.Key = GetKey(secret);
				
				var encryptor = aes.CreateEncryptor(aes.Key, new byte[aes.IV.Length]);

				using (var msEnc = new MemoryStream())
				using (var csEnc = new CryptoStream(msEnc, encryptor, CryptoStreamMode.Write))
				{
					using (var swEnc = new StreamWriter(csEnc))
						swEnc.Write(strToEncrypt);

					return Convert.ToBase64String(msEnc.ToArray());
				}
            }

			throw new NotImplementedException();
		}

		private static byte[] GetKey(string key)
        {
			var supportedKeyLength = new int[] { 16, 24, 32 };

			var bytes = Encoding.UTF8.GetBytes(key);

			foreach (var length in supportedKeyLength)
			{
				if (bytes.Length <= length)
				{
					if (bytes.Length == length)
						return bytes;

					var result = new byte[length];

					Array.Copy(bytes, result, bytes.Length);

					return result;
				}
			}

			throw new ArgumentException("Unsupported key length.");
		}

		public static string Decrypt(string strToDecrypt, string secret)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = GetKey(secret);

				var decryptor = aes.CreateDecryptor(aes.Key, new byte[aes.IV.Length]);

				using (var msEnc = new MemoryStream(Convert.FromBase64String(strToDecrypt)))
				using (var csEnc = new CryptoStream(msEnc, decryptor, CryptoStreamMode.Read))
				{
					using (var swEnc = new StreamReader(csEnc))
						return swEnc.ReadToEnd();
				}
			}

			throw new NotImplementedException();
		}
	}
}
