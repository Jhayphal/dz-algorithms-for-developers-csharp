using System;

namespace Max3
{
	class Program
	{
		static void Main(string[] args)
		{
			int ageMom = 39;
			int ageDad = 41;
			int maxAge = Math.Max(ageMom, ageDad);
			int ageGrandma = 63;
			maxAge = Math.Max(maxAge, ageGrandma);
			Console.WriteLine($"MaxAge = {maxAge}");
			Console.ReadLine();
		}
	}
}
