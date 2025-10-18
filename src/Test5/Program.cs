/*5. Класс “Студент и оценки”
Класс Student: имя + список оценок.
    Методы:

* AddGrade() — добавить оценку
* GetAverageGrade() — средний балл
* PrintInfo() — вывести информацию
*/

var tom = new Student("Tom");
List<int?> grades = [5, 4, 3, 2, 3, 4, 3, 2, 4, 2];
tom.AddGrade(5);
tom.AddGrades(grades);
tom.PrintAverageGrades();
tom.PrintInfo();


internal class Student(string name)
{
    private readonly List<int?> _grades = new();

    public void AddGrade(int? grade)
    {
        if (grade == null)
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