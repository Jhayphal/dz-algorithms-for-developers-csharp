using NUnit.Framework;

namespace MergeSortRecursion
{
	public class MergeSortRecursionTest
	{
		private static readonly object[] ProviderMergeTwoListsTest =
		{
			new object[] {new ListNode(1) {Next = new ListNode(2) {Next = new ListNode(4)} }, new ListNode(1) {Next = new ListNode(3) {Next = new ListNode(4)} }, 6 },
			new object[] {null, new ListNode(5), 1 },
			new object[] {null, null, 0 }
		};


		private static readonly object[] ProviderMergeThreeListsTest =
		{

			new object[] {
				new ListNode(1) { Next = new ListNode(2) {Next = new ListNode(4)} },
				new ListNode(1) { Next = new ListNode(3) {Next = new ListNode(4)} },
				new ListNode(2) { Next = new ListNode(4) {Next = new ListNode(6)} },
				9 },
			new object[] {  null,               new ListNode(5),    null, 1 },
			new object[] {  new ListNode(1),    new ListNode(5),    null, 2 },
			new object[] {  null,               null,               null, 0 }
		};

		static private bool IsSorted(ListNode head)
		{
			if (head == null || head.Next == null)
				return true;
			return (head.Val <= head.Next.Val && IsSorted(head.Next));
		}

		static private int GetListLength(ListNode node)
		{
			if (node == null) return 0;
			return 1 + GetListLength(node.Next);
		}


		[Test(Description = "Merge 2 sorted LinkedList")]
		[TestCaseSource(nameof(ProviderMergeTwoListsTest))]
		public void PossibleMessagesTest(ListNode l1, ListNode l2, int size)
		{
			var actual = MergeSortRecursion.MergeTwoLists(l1, l2);

			Assert.IsTrue(IsSorted(actual));
			Assert.AreEqual(size, GetListLength(actual));
		}


		[Test(Description = "Merge 3 sorted LinkedList")]
		[TestCaseSource(nameof(ProviderMergeThreeListsTest))]
		public void PossibleMessagesTest(ListNode l1, ListNode l2, ListNode l3, int size)
		{
			var actual = MergeSortRecursion.MergeThreeLists(l1, l2, l3);

			Assert.IsTrue(IsSorted(actual));
			Assert.AreEqual(size, GetListLength(actual));
		}
	}
}