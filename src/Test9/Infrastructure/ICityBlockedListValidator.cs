namespace Infrastructure;

public interface ICityBlockedListValidator
{
    Task<string> GetWeatherAsync(string cityName);
}