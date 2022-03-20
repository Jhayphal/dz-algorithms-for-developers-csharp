using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
	public class Courses
	{
		public static bool CanFinish(int numCourses, int[,] prerequisites)
		{
			HashSet<int> checkedOk = new HashSet<int>(); // список проверенных и "проходимых" курсов
			HashSet<int> visited = new HashSet<int>(); // список посещенных курсов

			for (int course = 0; course < numCourses; course++)
            {
				visited.Clear();

				int? dependencyCourse = course;

				while (true)
				{
					dependencyCourse = getDependency(dependencyCourse.Value, prerequisites);

					if (dependencyCourse == null)
					{
						checkedOk.Add(course);

						break;
					}

					if (checkedOk.Contains(dependencyCourse.Value)) // если уже проверили этот курс и с ним всё ок
						break;

					if (visited.Contains(dependencyCourse.Value)) // циклическая зависимость
						return false;

					visited.Add(dependencyCourse.Value);
				}
			}

			return true;
		}

		private static int? getDependency(int course, int[,] prerequisites)
        {
			for (int i = 0; i < prerequisites.GetLength(0); ++i)
				if (prerequisites[i, 0] == course)
					return prerequisites[i, 1];

			return null;
        }
	}
}
