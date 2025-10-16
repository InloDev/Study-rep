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
var selectedAgePerson = from person in persons where person.Age > 18 orderby person.Age select person;
var sortAgePerson = from person in persons orderby person.Age select person;
var middleAgePerson = persons.Average(person => person.Age);
var selectedNameSizePerson = from person in persons where person.Name.Length >= 5 orderby person.Name select person;

Console.WriteLine("Возраст больше 18");
foreach (var person in selectedAgePerson) Console.WriteLine($"{person.Name} - {person.Age}");
Console.WriteLine("Отсортированно по возрасту");
foreach (var person in sortAgePerson) Console.WriteLine($"{person.Name} - {person.Age}");
Console.WriteLine();
Console.WriteLine($"Средний возраст - {middleAgePerson}");
Console.WriteLine();
Console.WriteLine("Длинна имени больше 5 символов");
foreach (var person in selectedNameSizePerson) Console.WriteLine($"{person.Name} - {person.Age}");

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