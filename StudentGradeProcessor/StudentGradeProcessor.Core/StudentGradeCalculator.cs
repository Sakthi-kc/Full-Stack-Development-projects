using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradeProcessor.Core
{
    public class StudentGradeCalculator : IStudentGradeCalculator
    {
        private readonly AppConfig _config;

        public StudentGradeCalculator(AppConfig config)
        {
            _config = config;
        }


        public decimal CalculateAverage(IEnumerable<decimal> marks)
        {
            if (marks == null)
                throw new ArgumentNullException(nameof(marks));

            var markList = marks.ToList(); // Avoid multiple enumeration

            if (markList.Count == 0)
                throw new ArgumentException("Marks collection cannot be empty.", nameof(marks));

            if (marks.Any(mark => mark < _config.minMark || mark > _config.maxMark))
                throw new ArgumentOutOfRangeException(nameof(marks),
                    "Each mark must be between 0 and 100.");

            return markList.Average();
        }

        public char CalculateGrade(decimal average)
        {
            if (average < _config.minMark || average > _config.maxMark)
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
