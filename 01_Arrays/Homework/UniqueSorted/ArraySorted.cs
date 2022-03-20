using System;
using System.Collections.Generic;

namespace UniqueSorted
{
	public class ArraySorted
	{
		/// <summary>
		/// <seealso cref="Printer.PrintPhoneInfo(long, int)"/>
		/// </summary>
		public static Dictionary<long, long> GroupAndPrint(long[] phoneNumbers)
		{
			var result = new Dictionary<long, long>();

			foreach (var phone in phoneNumbers)
				if (result.TryGetValue(phone, out long count))
					result[phone] = count + 1;
				else
					result.Add(phone, 1);

			return result;
		}

		/// <summary>
		/// <seealso cref="Printer.PrintCurrencyInfo(string, double)"/>
		/// </summary>
		public static Dictionary<string, double> CryptoCurrencyAnalysis(string fileContents)
		{
			if (string.IsNullOrWhiteSpace(fileContents))
				return new Dictionary<string, double>();

			var temp = new Dictionary<string, List<double>>();

			foreach (var line in fileContents.Split())
			{
				if (string.IsNullOrWhiteSpace(line))
					continue;

				var currencyInfo = line.Split(':');

				string currencyName = currencyInfo[0];
				double currencyValue = double.Parse(currencyInfo[1]);

				if (temp.TryGetValue(currencyName, out var values))
					values.Add(currencyValue);
				else
					temp.Add(currencyName, new List<double> { currencyValue });
			}

			var result = new Dictionary<string, double>();

			foreach (var item in temp)
			{
				double sum = 0D;

				foreach (var value in item.Value)
					sum += value;

				result.Add(item.Key, sum / item.Value.Count);
			}

			return result;
		}
	}
}
