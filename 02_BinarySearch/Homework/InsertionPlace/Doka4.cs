using BinarySearch.Common;
using System;

namespace InsertionPlace
{
	public class Doka4
	{
		public static int SearchRightmostPlayerWithRating(Player[] queue, int ratingBand)
		{
			int length = queue?.Length ?? 0;

			if (length == 0)
				return -1;

			int left = 0;
			int right = length - 1;

			while (left < right)
			{
				int middle = (right + left) / 2;
				var current = queue[middle];

				if (current.Rating > ratingBand)
					right = middle - 1;

				else
					left = middle + 1;
			}

			return queue[left].Rating == ratingBand
				? left
				: -1;
		}

		public static void InsertPlayerInQueueWithShift(Player[] queue, int index, Player newPlayer)
		{
			int length = queue?.Length ?? 0;

			if (length == 0)
				throw new ArgumentException(nameof(queue));

			for (int i = length - 1; i > index; --i)
				queue[i] = queue[i - 1];

			queue[index] = newPlayer;
		}
	}
}
