using System;
using System.Collections.Generic;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var limitForA = (int) (Students.Count * 0.2);
            var limitForB = (int) (Students.Count * 0.4);
            var limitForC = (int) (Students.Count * 0.6);
            var limitForD = (int) (Students.Count * 0.8);
            var averageGrades = new List<double>();

            foreach (Student student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }

            averageGrades.Sort();

            for (int i = 0; i < Students.Count; i++)
            {
                if (averageGrade > averageGrades[i])
                {
                    if (i + 1 <= limitForA)
                    {
                        return 'A';
                    }
                    else if (i + 1 <= limitForB)
                    {
                        return 'B';
                    }
                    else if (i + 1 <= limitForC)
                    {
                        return 'C';
                    }
                    else if (i + 1 <= limitForD)
                    {
                        return 'D';
                    }
                }
            }

            return 'F';
        }
    }
}
