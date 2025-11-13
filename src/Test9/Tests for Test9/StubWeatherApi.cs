using Application;
using Infrastructure;

namespace Tests;

public sealed class StubWeatherApi : IWeatherApi
{
    public Task<WeatherInfo> GetAsync(string cityName)
    {
        var stubData = new WeatherInfo(cityName, "Солнечно", 15, 30);
        return Task.FromResult(stubData);
    }
}