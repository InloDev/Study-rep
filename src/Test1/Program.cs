using Test1;

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
var selectedAgePerson = persons.Where(person => person.Age > 18).OrderBy(person => person.Age);
var sortAgePerson = persons.OrderBy(person => person.Age);
var middleAgePerson = persons.Average(person => person.Age);
var selectedNameSizePerson = persons.Where(person => person.Name.Length >= 5).OrderBy(person => person.Name);

Console.WriteLine("Возраст больше 18");
foreach (var person in selectedAgePerson) Console.WriteLine($"{person.Name} - {person.Age}");
Console.WriteLine("Отсортированно по возрасту");
foreach (var person in sortAgePerson) Console.WriteLine($"{person.Name} - {person.Age}");
Console.WriteLine();
Console.WriteLine($"Средний возраст - {middleAgePerson}");
Console.WriteLine();
Console.WriteLine("Длинна имени больше 5 символов");
foreach (var person in selectedNameSizePerson) Console.WriteLine($"{person.Name} - {person.Age}");