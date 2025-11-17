using Application;

namespace Infrastructure;

public interface IWeatherApi
{
    Task<WeatherInfo> GetWeatherApiAsync(string cityName);
}