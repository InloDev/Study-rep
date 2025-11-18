using Application;

namespace Infrastructure;

public interface IWeatherService
{
    Task<WeatherInfo> GetWeatherServiceAsync(string cityName);
}