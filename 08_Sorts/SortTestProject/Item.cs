using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTestProject
{
	public class Item : IComparable<Item>
	{

		private static long amountEquals;
		private static long amountCompareTo;
		readonly int data;

		public Item(int data)
		{
			this.data = data;
		}

		public static long GetAmountEquals()
		{
			return amountEquals;
		}

		public static long GetAmountCompareTo()
		{
			return amountCompareTo;
		}

		public static void ClearAmountCompareTo()
		{
			amountCompareTo = 0;
		}

		public int getData()
		{
			return data;
		}


		public override bool Equals(object o)
		{
			amountEquals++;

			if (this == o)
			{
				return true;
			}
			if (o == null || GetType() != o.GetType())
			{
				return false;
			}
			Item item = (Item)o;
			return data == item.data;
		}


		public int CompareTo(Item o)
		{
			amountCompareTo++;
			return data.CompareTo(o.data);
		}
	}
}
