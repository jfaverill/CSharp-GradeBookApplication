﻿using System;
using System.Collections.Generic;
using GradeBook.Enums;
using System.Linq;

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

            var limitForA = (int) Math.Ceiling(Students.Count * 0.2);
            var limitForB = (int) Math.Ceiling(Students.Count * 0.4);
            var limitForC = (int) Math.Ceiling(Students.Count * 0.6);
            var limitForD = (int) Math.Ceiling(Students.Count * 0.8);
            var averageGrades = new List<double>();

            foreach (Student student in Students)
            {
                averageGrades.Add(student.AverageGrade);
            }

            averageGrades.Sort();
            averageGrades.Reverse();

            if (averageGrade >= averageGrades[limitForA - 1])
            {
                return 'A';
            }
            else if (averageGrade >= averageGrades[limitForB - 1])
            {
                return 'B';
            }
            else if (averageGrade >= averageGrades[limitForC - 1])
            {
                return 'C';
            }
            else if (averageGrade >= averageGrades[limitForD - 1])
            {
                return 'D';
            }
       
            return 'F';
        }
    }
}
