using Application;

namespace Infrastructure;

public sealed class WeatherService(IOpenWeatherApi weatherApi) : IWeatherService
{
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";

    private readonly HashSet<string> _bannedCities = new(StringComparer.OrdinalIgnoreCase)
    {
        "Кишинев", "N", "Киев"
    };

    public async Task<WeatherInfo> GetWeatherInfoAsync(string cityName)
    {
        if (_bannedCities.Contains(cityName))
            throw new InvalidOperationException($"Запрос погоды для города '{cityName}' запрещен.");

        var weatherResponse = await weatherApi.GetOpenWeatherApiAsync(cityName, ApiKey);

        var weatherInfo = new WeatherInfo(
            weatherResponse.Name,
            weatherResponse.Weather[0].Description,
            weatherResponse.Main.Temp,
            weatherResponse.Wind.Speed);
        return weatherInfo;
    }
}