using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnobviousGraphs
{
	public class Tests
	{
		private static readonly object[] islands = new object[]
		{
				new object[] {"A:B,C \n B:A,C \n C:A,B", true },
				new object[] {"A:B,C \n B:A,C,D \n C:A,B \n D:B", true },
				new object[] {"A:C \n B:D \n C:A \n D:B", false },
				new object[] {"A: B,C \n B: A,C,C,D \n C: A,B,B \n D:B,E \n E:D", true },
				new object[] {"A: B,C,D \n B:A,D \n C:A,D \n D:A,B,C", true }, // исправил, т.к. этот вариант соответствует всем правилам
				new object[] {"A: D \n B:D \n C:D \n D:A,B,C", false },
				new object[] {"Kotlin: Java \n JS:Java \n C#:Java \n Java:Kotlin,JS,C#", false },
				new object[] {"1: 2,5 \n 2:1,5 \n 3:4,5,6 \n 4:3,6 \n 5:1,2,3,6 \n 6:3,4,5", true },
				new object[] {"1: 2,5 \n 2:1,5 \n 3:4,5,6 \n 4:3 \n 5:1,2,3,6 \n 6:3,4,5", false },
				new object[] {"1: 2,5 \n 2:1,5 \n 3:4,4,5,6 \n 4:3,3,6 \n 5:1,2,3,6 \n 6:3,4,5", true },
				new object[] {"1: 2,5,7 \n 2:1,3,4,5,6,6,7 \n 3:2,4 \n 4:2,3 \n 5:1,2 \n 6:2,2 \n 7:1,2", true }
		};

		[Test(Description = "Bridges and Islands")]
		[TestCaseSource(nameof(islands))]
		public void ValidProject(string str, bool expected)
		{
			var islands = Read(str);
			Assert.AreEqual(expected, Bridges.IsProjectSuccess(islands), "Предложенный проект:\n" + islands);
		}

		private static Dictionary<string, List<string>> Read(string projectCode)
		{
			string[] islands = projectCode.Trim().Split("\n");

			Dictionary<string, List<string>> project = new Dictionary<string, List<string>>();

			foreach (var island in islands)
			{
				string[] row = island.Split(":");
				project.Add(row[0].Trim(), row[1].Trim().Split(",").ToList());
			}

			return project;
		}
	}
}