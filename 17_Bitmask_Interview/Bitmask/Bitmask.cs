using System;
using System.Net;

namespace Bitmask
{
    public class Bitmask
	{
		// Возвращает битовую маску по ip адресу
		// "0.0.0.0" -> 0
		// "127.0.0.1" -> 2130706433
		public static int IpToMask(string s)
		{
			var mask = IPAddress.Parse(s);

			return BitConverter.ToInt32(mask.GetAddressBytes(), 0);
		}

		// Возвращает, является ли submask подмаской mask
		public static bool IsSubmask(string mask, string submask)
		{
			var mdata = IpToMask(mask);
			var sdata = IpToMask(submask);

			return (mdata & sdata) == sdata;
		}

		// Возвращает битовую маску циклически сдвинутую на cnt
		// Циклы использовать запрещено. cnt может быть меньше 0 и больше 32.
		// rotate(1, 1) == 2
		// rotate(1, -1) == -2147483648
		public static uint Rotate(uint mask, int cnt)
		{
			if (cnt == 0)
				return mask;

			const int UIntBitsCount = sizeof(uint) * 8;

			cnt %= UIntBitsCount;

			if (cnt < 0)
				return (mask << (UIntBitsCount + cnt)) | (mask >> -cnt);

			return (mask << cnt) | (mask >> (UIntBitsCount - cnt));
		}
	}

}
