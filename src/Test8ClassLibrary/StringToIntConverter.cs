namespace Test8ClassLibrary;

public class StringToIntConverter : IConverter<string, int>
{
    public int Convert(string input)
    {
        if (int.TryParse(input, out var result))
            return result;

        throw new FormatException($"Невозможно преобразовать строку '{input}' в число.");
    }
}