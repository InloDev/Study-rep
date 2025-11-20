using Application;

namespace Infrastructure;

public interface IWeatherService
{
    Task<WeatherInfo> GetWeatherInfoAsync(string cityName);
}