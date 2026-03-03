using StudentGradeProcessor.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentGradeProcessor.Tests
{
    [TestClass]
    public class StudentGradeCalculatorTests
    {
        private IStudentGradeCalculator _calc;

        [TestInitialize]
        public void StartUp()
        {
            _calc = new StudentGradeCalculator();
        }

        [TestMethod]
        [DataRow(97.5032)]
        public void CalculateGrade_AvgMoreThan90(double average)
        {
            //Arrange
            decimal avg = Convert.ToDecimal(average);

            //Act
            var grade = _calc.CalculateGrade(avg);

            //Assert
            Assert.AreEqual('A', grade);

        }
    }
}
