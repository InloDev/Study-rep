internal class Student(string name)
{
    private readonly List<int?> _grades = new();

    public void AddGrade(int? grade)
    {
        if (grade is null)
            Console.WriteLine("Недопустимые значения");

        _grades.Add(grade);
    }

    public void AddGrades(List<int?> grades)
    {
        _grades.AddRange(grades);
    }

    public void PrintAverageGrades()
    {
        Console.WriteLine($"Average grade: {_grades.Average()}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.Write("Grades: ");
        foreach (var grade in _grades) Console.Write($"{grade} ");
    }
}