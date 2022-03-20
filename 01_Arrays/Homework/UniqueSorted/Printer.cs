using System;

namespace UniqueSorted
{
	public class Printer
	{
		public static void PrintPhoneInfo(long phone, int count)
		{
			Console.WriteLine($"+{phone} — поступило заявок: {count}");
		}

		public static void PrintCurrencyInfo(string name, double amount)
		{
			Console.WriteLine($"{name}: {amount}", name, amount);
		}
	}
}
