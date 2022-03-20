using NUnit.Framework;
using System;

namespace Bitmask
{
	public class BitmaskTest
	{
		[Test]
		public void TestIsSubmask()
		{
			var rn = new Random();
			for (int i = 0; i < 1000; ++i)
			{
				int[] a = new int[4];
				int[] b = new int[4];
				for (int j = 0; j < 4; ++j)
				{
					a[j] = rn.Next(256);
				}
				var f = true;
				for (int j = 0; j < 4; ++j)
				{
					b[j] = rn.Next(256);
					if ((a[j] & b[j]) != b[j])
					{
						f = false;
					}
				}
				if (rn.Next(2) == 0)
				{
					f = true;
					for (int j = 0; j < 4; ++j)
					{
						b[j] &= a[j];
					}
				}
				var s1 = a[0].ToString();
				var s2 = b[0].ToString();
				for (int j = 1; j < 4; ++j)
				{
					s1 += "." + a[j];
					s2 += "." + b[j];
				}
				Assert.AreEqual(f, Bitmask.IsSubmask(s1, s2));
			}
		}

		public uint Rotr(uint x)
		{
			uint c = x & 1;
			x = x >> 1;
			x = x | (c << 31);
			return x;
		}

		public uint Rotl(uint x)
		{
			uint c = x >> 31;
			x = x << 1;
			x = ((x | 1) ^ 1) ^ c;
			return x;
		}

		[Test]
		public void TestRotate()
		{
			Random rn = new Random();
			for (int i = 0; i < 10000; ++i)
			{
				uint x = (uint) rn.Next();
				int c = rn.Next(200);
				if (rn.Next(2) == 0)
				{
					c *= -1;
				}
				uint ex = x;
				if (c > 0)
				{
					for (int j = 0; j < c; ++j)
					{
						ex = Rotl(ex);
					}
				}
				else
				{
					for (int j = 0; j < -c; ++j)
					{
						ex = Rotr(ex);
					}
				}
				Assert.AreEqual(ex, Bitmask.Rotate(x, c));
			}
		}
	}
}