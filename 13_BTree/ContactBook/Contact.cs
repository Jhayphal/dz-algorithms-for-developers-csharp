using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
	public class Contact
	{

		public readonly string Name;
		public readonly string Number;

		public Contact(string name, string number)
		{
			Name = name;
			Number = number;
		}


		public override string ToString()
		{
			return "{name='" + Name + '\'' +
				   ", number='" + Number + '\'' +
				   '}';
		}
	}
}
