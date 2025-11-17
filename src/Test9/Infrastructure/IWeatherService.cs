namespace Infrastructure;

public interface IWeatherService
{
    Task<string> GetWeatherServiceAsync(string cityName);
}