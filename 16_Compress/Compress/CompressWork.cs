using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compress
{
    public class CompressWork
	{
		public static string Compress(string graduatedWork)
		{
			var result = new StringBuilder();
			var current = char.MinValue;
			var count = 0;

			foreach(var c in graduatedWork)
            {
				if (c != current)
                {
					if (count > 0)
                    {
						result.Append(current);
						result.Append(count);
                    }

					count = 0;
					current = c;
                }

				++count;
            }

			if (count > 0)
			{
				result.Append(current);
				result.Append(count);
			}

			return result.ToString();
		}

		public static string Decompress(string graduatedWork)
		{
			var current = char.MinValue;
			var result = new StringBuilder();
			var number = new StringBuilder();

			foreach(var c in graduatedWork)
            {
				if (char.IsDigit(c))
				{
					number.Append(c);

					continue;
				}

				else if (number.Length > 0)
				{
					var count = int.Parse(number.ToString());

					result.Append(new string(current, count));

					number.Clear();
				}

				current = c;
			}

			if (number.Length > 0)
			{
				var count = int.Parse(number.ToString());

				result.Append(new string(current, count));

				number.Clear();
			}

			return result.ToString();
		}

		public static List<string> RemoveComments(string[] source)
		{
			return new CommentClearer()
				.Clear(source)
				.ToList();
		}
	}
}
