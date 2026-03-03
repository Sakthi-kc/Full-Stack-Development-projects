using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGradeProcessor.Core;

//Dependency injection

var services = new ServiceCollection();
services.AddScoped<IStudentGradeCalculator, StudentGradeCalculator>();
var serviceProvider = services.BuildServiceProvider();


var gradeCalculator = serviceProvider.GetRequiredService<IStudentGradeCalculator>();


//setup configuration

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appSettings.json")
    .Build();


//main program

Console.WriteLine("Let's calculate student average and grade!\n\n");

int numberOfSubjects = int.Parse(config["NumberOfSubjects"]);
var marks = new List<decimal>();

Console.WriteLine($"Please enter your marks for {numberOfSubjects} subjects");

int minMark = int.Parse(config["Marks:MinMark"]), maxMark = int.Parse(config["Marks:MaxMark"]);

try
{
    //ReadMarks
    for (int i = 1; i <= numberOfSubjects; i++)
    {
        Console.Write($"Mark {i}: ");
        decimal mark;
        while (!decimal.TryParse(Console.ReadLine(), out mark) || mark < minMark || mark > maxMark)
        {
            Console.WriteLine($"Please provide a valid mark between {minMark} - {maxMark}");
        }

        marks.Add(mark);
    }


    //FindAverage
    decimal average = gradeCalculator.CalculateAverage(marks, minMark, maxMark);


    //FindGrade
    char grade = gradeCalculator.CalculateGrade(average);
    Console.WriteLine($"\nYou have got grade: {grade}");

    //Need to print pass or fail
    Console.WriteLine($"\nResult: {gradeCalculator.CalculateResult(grade)}");

}
catch(Exception Ex)
{
    Console.WriteLine(Ex);
}
