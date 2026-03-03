using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentGradeProcessor.Core;


//setup configuration

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appSettings.json")
    .Build();


var marksConfig = config
    .GetSection("Config")
    .Get<AppConfig>();


//Dependency injection

var services = new ServiceCollection();
services.AddScoped<IStudentGradeCalculator, StudentGradeCalculator>();
var serviceProvider = services.BuildServiceProvider();


var gradeCalculator = serviceProvider.GetRequiredService<IStudentGradeCalculator>();


//main program

Console.WriteLine("Let's calculate student average and grade!\n\n");

int numberOfSubjects = marksConfig.numberOfSubjects;
var marks = new List<decimal>();

Console.WriteLine($"Please enter your marks for {numberOfSubjects} subjects");

try
{
    //ReadMarks
    for (int i = 1; i <= numberOfSubjects; i++)
    {
        Console.Write($"Mark {i}: ");
        decimal mark;
        while (!decimal.TryParse(Console.ReadLine(), out mark) || mark < marksConfig.minMark || mark > marksConfig.maxMark)
        {
            Console.WriteLine($"Please provide a valid mark between {marksConfig.minMark} - {marksConfig.maxMark}");
        }

        marks.Add(mark);
    }


    //FindAverage
    decimal average = gradeCalculator.CalculateAverage(marks);


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
