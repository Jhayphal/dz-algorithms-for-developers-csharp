using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
	public interface ISuperArray
	{
		int GetSize();
		int Get(int position);
		void Set(int position, int value);
	}
}
