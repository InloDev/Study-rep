namespace Test8ClassLibrary;

public interface IConverter<in TInput, out TOutput>
{
    TOutput Convert(TInput input);
}