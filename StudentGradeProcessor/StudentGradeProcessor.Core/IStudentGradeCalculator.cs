using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradeProcessor.Core
{
    public interface IStudentGradeCalculator
    {
        decimal CalculateAverage(IEnumerable<decimal> marks, int minMark, int maxMark);

        char CalculateGrade(decimal average);

        string CalculateResult(char grade);
    }
}
