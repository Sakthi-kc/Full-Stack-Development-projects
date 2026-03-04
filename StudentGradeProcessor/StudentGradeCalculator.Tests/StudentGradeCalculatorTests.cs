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
            var mockConfig = new AppConfig
            {
                minMark = 0,
                maxMark = 100,
                numberOfSubjects = 5
            };

            _calc = new StudentGradeCalculator(mockConfig);
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

        [TestMethod]
        [DataRow(70)]
        public void CalculateGrade_BoundaryCase70(double average)
        {
            decimal avg = Convert.ToDecimal(average);

            var grade = _calc.CalculateGrade(avg);

            Assert.AreEqual('C', grade);
        }


        [TestMethod]
        public void CalculateAverage_ExceptionTesting()
        {
            //Arrange
            List<decimal> testList = new List<decimal>();


            //Act+Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _calc.CalculateAverage(testList);
            });


        }

    }
}
