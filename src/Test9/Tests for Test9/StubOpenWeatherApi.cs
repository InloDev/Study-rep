using Infrastructure;

namespace Tests;

internal sealed class StubOpenWeatherApi : IOpenWeatherApi
{
    private static readonly TempInfoDto DefaultTemp = new(15);
    private static readonly WindInfoDto DefaultWind = new(30);
    private static readonly WeatherInfoDto[] DefaultWeather = [new("Солнечно")];
    private readonly WeatherTransfer _stubData = new(
        DefaultTemp,
        DefaultWind,
        "TestCity",
        DefaultWeather);

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