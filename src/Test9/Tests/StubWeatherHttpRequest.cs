using Application;
using Infrastructure;

namespace Tests;

public sealed class StubHttpRequest : IWeatherApi
{
    public Task<WeatherInfo> GetResponseAsync(string cityName)
    {
        /*
    [InlineData("  ")]
    [InlineData("")]
         */

        if (string.IsNullOrWhiteSpace(cityName))
            throw new Exception();
        var stubData = new WeatherInfo(cityName, "Солнечно", 15, 30);
        return Task.FromResult(stubData);
    }
}