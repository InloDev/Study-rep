var persons = new List<Person>
{
    new("Tom", 18),
    new("Janis", 24),
    new("Alan", 10),
    new("Sam", 57),
    new("Jack", 27),
    new("Mike", 15),
    new("Jill", 54),
    new("Valentine", 30)
};
var selectedAgePerson = from p in persons where p.Age > 18 orderby p.Age select p;
var sortAgePerson = from p in persons orderby p.Age select p;
var middleAgePerson = persons.Average(p => p.Age);
var selectedNameSizePerson = from p in persons where p.Name.Length >= 5 orderby p.Name select p;

Console.WriteLine("Возраст больше 18");
foreach (var p in selectedAgePerson) Console.WriteLine($"{p.Name} - {p.Age}");
Console.WriteLine("Отсортированно по возрасту");
foreach (var p in sortAgePerson) Console.WriteLine($"{p.Name} - {p.Age}");
Console.WriteLine();
Console.WriteLine($"Средний возраст - {middleAgePerson}");
Console.WriteLine();
Console.WriteLine("Длинна имени больше 5 символов");
foreach (var p in selectedNameSizePerson) Console.WriteLine($"{p.Name} - {p.Age}");

internal class Person
{
    public int Age;
    public string Name;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}