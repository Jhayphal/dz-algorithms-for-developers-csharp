using BinarySearch.Common;
using System;

namespace PlayersQueue
{
	class Program
	{
		private static Player[] queue = new Player[]
		{
				new Player(1000, "Crowbar Freeman"),
				new Player(1000, "London Mollarik"),
				new Player(1010, "London Mollarik 10"),
				new Player(1012, "London Mollarik 12"),
				new Player(1014, "London Mollarik 14"),
				new Player(1016, "London Mollarik 16"),
				new Player(1016, "London Mollarik 18"),
				new Player(1500, "Raziel of Kain"),
				new Player(1500, "Gwinter of Rivia"),
				new Player(1500, "Slayer of Fate"),
				new Player(3000, "Jon Know"),
				new Player(4000, "Caius Cosades")
		};

		static void Main(string[] args)
		{
			Console.WriteLine("1011:" + queue[SearchLeftmostPlayerWithRating(queue, 1011)].NickName);
			Console.WriteLine("1013:" + queue[SearchLeftmostPlayerWithRating(queue, 1013)].NickName);
			Console.WriteLine("1015:" + queue[SearchLeftmostPlayerWithRating(queue, 1015)].NickName);
			Console.WriteLine("1017:" + queue[SearchLeftmostPlayerWithRating(queue, 1017)].NickName);
			Console.ReadLine();
		}

		public static int SearchLeftmostPlayerWithRating(Player[] queue, int search)
		{
			int left = 0;
			int right = queue.Length;
			while (left < right)
			{
				int middle = (left + right) / 2;
				if (queue[middle].Rating < search)
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
