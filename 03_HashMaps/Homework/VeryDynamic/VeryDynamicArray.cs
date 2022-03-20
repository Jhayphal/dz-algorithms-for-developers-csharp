using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeryDynamic
{
	public class VeryDynamicArray<T> : List<T>
	{
		public void DeleteElementAt(int index)
		{
			// я не понял, чего вы от меня хотите
			RemoveAt(index);
		}
	}
}
