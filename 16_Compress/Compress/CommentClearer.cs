using System.Collections.Generic;

namespace Compress
{
    internal class CommentClearer
    {
		private const string Single = "//";
		private const string Open = "/*";
		private const string Close = "*/";

		private bool hasOpen;

        public IEnumerable<string> Clear(IEnumerable<string> source)
        {
			foreach (var line in source)
			{
				if (hasOpen)
				{
					var index = line.IndexOf(Close);

					if (index > -1)
					{
						var result = line.Substring(index + Close.Length).Trim();

						if (!string.Equals(result, string.Empty))
							yield return result;

						hasOpen = false;
					}
				}
				else
				{
					var result = ClearLine(line).Trim();

					if (!string.Equals(result, string.Empty))
						yield return result;
				}
			}
		}

		private string ClearLine(string line)
        {
			var indexOfSingleLineComment = line.IndexOf(Single);
			var indexOfMultyLineComment = line.IndexOf(Open);

			if (indexOfMultyLineComment < 0 && indexOfSingleLineComment < 0)
				return line;

			if (indexOfMultyLineComment > -1 && indexOfSingleLineComment > -1)
            {
				if (indexOfSingleLineComment < indexOfMultyLineComment)
					return line.Substring(0, indexOfSingleLineComment);

				return ClearLine(RemoveMultyLineComment(line));
            }

			if (indexOfSingleLineComment > -1)
				return line.Substring(0, indexOfSingleLineComment);

			return ClearLine(RemoveMultyLineComment(line));
		}

		private string RemoveMultyLineComment(string line)
        {
			var indexOfMultyLineCommentOpen = line.IndexOf(Open);
			var indexOfMultyLineCommentClose = line.IndexOf(Close);

			if (indexOfMultyLineCommentOpen < 0)
				return line;

			hasOpen = true;

			if (indexOfMultyLineCommentClose < 0)
				return line.Substring(0, indexOfMultyLineCommentOpen);

			hasOpen = false;

			return line.Substring(0, indexOfMultyLineCommentOpen)
				+ line.Substring(indexOfMultyLineCommentClose + Close.Length);
		}
	}
}
