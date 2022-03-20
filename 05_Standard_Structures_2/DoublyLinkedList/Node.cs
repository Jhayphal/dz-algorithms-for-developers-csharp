namespace DoublyLinkedList
{
	public class Node
	{
		public int X { get; set; }
		public Node Next { get; set; }
		public Node Prev { get; set; }
		
		public Node(int x)
		{
			X = x;
			Next = null;
			Prev = null;
		}
	}
}
