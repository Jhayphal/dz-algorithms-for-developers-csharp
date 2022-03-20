using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
	public class Receipt
	{
		public readonly int ReceiptNumber;
		public readonly double Amount;

		public Receipt(int receiptNumber, double amount)
		{
			ReceiptNumber = receiptNumber;
			Amount = amount;
		}


		public override string ToString()
		{
			return "Receipt{checkNumber=" + ReceiptNumber + "}";
		}
	}
}
