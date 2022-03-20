namespace BinarySearch.Common
{
	public class Player
	{
		public int Rating { get; private set; }
		public string NickName { get; private set; }

		public Player(int rating, string nickName)
		{
			Rating = rating;
			NickName = nickName;
		}
	}
}
