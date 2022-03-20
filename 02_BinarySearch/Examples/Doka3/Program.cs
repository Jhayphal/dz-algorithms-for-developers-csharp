using BinarySearch.Common;
using System;

namespace Doka3
{
	class Program
	{
		// Наша рейтинговая таблица выглядит примерно так
		private static Player[] ratings = new Player[]
		{
            /*0*/ new Player(1100, "Crowbar Freeman"),
            /*1*/ new Player(1200, "London Mollarik"),
            // new Player(1600, "Shmike")
            /*2*/ new Player(1600, "Raziel of Kain"),
            /*3*/ new Player(1600, "Gwinter of Rivia"),
            /*4*/ new Player(1600, "Slayer of Fate"),
            /*5*/ new Player(3000, "Jon Know"),
            /*6*/ new Player(4000, "Caius Cosades"),
		};

		static void Main(string[] args)
		{
			int spot = FindSpot(ratings, new Player(1600, "Shmike"));
			Console.WriteLine(spot);
			Console.ReadLine();
		}


		public static int FindSpot(Player[] array, Player newPlayer)
		{
			int left = 0;
			int right = array.Length - 1;

			while (left < right)
			{
				int middle = (left + right) / 2;
				if (array[middle].Rating < newPlayer.Rating)
				{
					left = middle + 1;
				}
				else
				{
					right = middle;
				}
			}
			return left;
		}
	}
}
