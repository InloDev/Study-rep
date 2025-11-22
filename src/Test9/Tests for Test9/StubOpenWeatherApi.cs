using Infrastructure;

namespace Tests;

internal sealed class StubOpenWeatherApi : IOpenWeatherApi
{
    private readonly WeatherTransfer _stubData = new(
        new TempInfoDto(15),
        new WindInfoDto(30),
        "TestCity",
        [new("Солнечно")]);

    public Task<WeatherTransfer> GetOpenWeatherApiAsync
    (
        string cityName,
        string apiKey = "apiKey",
        string units = "metric",
        string lang = "ru"
    )
    {
        return Task.FromResult(_stubData);
    }
}