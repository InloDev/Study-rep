namespace Test1;

internal sealed class Person
{
    public Person(string name, int age)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfLessThan(age, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(age, 120);

        Name = name;
        Age = age;
    }

    public string Name { get; }
    public int Age { get; }
}