using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradeProcessor.Core
{
    public class StudentGradeCalculator : IStudentGradeCalculator
    {

        public decimal CalculateAverage(IEnumerable<decimal> marks, int minMark, int maxMark)
        {
            if (marks == null)
                throw new ArgumentNullException(nameof(marks));

            var markList = marks.ToList(); // Avoid multiple enumeration

            if (markList.Count == 0)
                throw new ArgumentException("Marks collection cannot be empty.", nameof(marks));

            if (marks.Any(mark => mark < minMark || mark > maxMark))
                throw new ArgumentOutOfRangeException(nameof(marks),
                    "Each mark must be between 0 and 100.");

            return markList.Average();
        }

        public char CalculateGrade(decimal average)
        {
            if (average < 0 || average > 100)
                throw new ArgumentOutOfRangeException(nameof(average),
                    "Average must be between 0 and 100.");


            var grade = average switch
            {
                >= 90M => 'A',
                >= 80M => 'B',
                >= 70M => 'C',
                _ => 'F'
            };

            return grade;
        }


        public string CalculateResult(char grade)
        {
            return grade == 'F' ? "Fail" : "Pass";
        }
    }
}
