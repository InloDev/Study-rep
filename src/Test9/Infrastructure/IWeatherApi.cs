using Application;

namespace Infrastructure;

public interface IWeatherApi
{
    Task<WeatherInfo> GetAsync(string cityName);
}