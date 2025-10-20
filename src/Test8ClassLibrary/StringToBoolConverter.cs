namespace Test8ClassLibrary;

public class StringToBoolConverter : IConverter<string, bool>
{
    public bool Convert(string input)
    {
        if (bool.TryParse(input, out var result))
            return result;

        throw new FormatException($"Невозможно преобразовать строку '{input}' в логическое значение.");
    }
}