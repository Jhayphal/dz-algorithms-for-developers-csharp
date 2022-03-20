using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortRecursion
{
	public class MergeSortRecursion
	{
		// Task #1
		public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
		{
			if (l1 == null)
				return l2;

			else if (l2 == null)
				return l1;

			var l1Val = l1.Val;
			var l2Val = l2.Val;

			bool choseL1 = l1Val < l2Val;
			
			int value = choseL1 ? l1Val : l2Val;

			var p1 = choseL1 ? l1?.Next : l2?.Next;
			var p2 = choseL1 ? l2 : l1;

			return new ListNode(value, MergeTwoLists(p1, p2));
		}

		// Task #2
		public static ListNode MergeThreeLists(ListNode l1, ListNode l2, ListNode l3)
		{
			return MergeTwoLists(l1, MergeTwoLists(l2, l3));
		}
	}
}
