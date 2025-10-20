namespace Test8ClassLibrary;

public class IntToStringConverter : IConverter<int, string>
{
    public string Convert(int input)
    {
        return input.ToString();
    }
}