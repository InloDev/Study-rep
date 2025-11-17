using Infrastructure;

namespace Tests;

public sealed class StubOpenWeatherApi : IOpenWeatherApi
{
    public Task<WeatherTransfer> GetOpenWeatherApiAsync(
    string cityName,
    string apiKey = "apiKey",
    string units = "metric",
    string lang = "ru")
    {
        var stubData = new WeatherTransfer
            (
                Main: new TempInfoDto(15),
                Wind: new WindInfoDto(30),
                Name: cityName,
            Weather: [new WeatherInfoDto("Солнечно")]
            );
        return Task.FromResult(stubData);
    }
}
