namespace Infrastructure;

public sealed class WeatherService(IWeatherApi weatherApi) : IWeatherService
{
    private readonly HashSet<string> _bannedCities = new(StringComparer.OrdinalIgnoreCase)
    {
        "Кишинев", "N", "Киев"
    };

    public async Task<string> GetWeatherServiceAsync(string cityName)
    {
        if (_bannedCities.Contains(cityName))
            throw new InvalidOperationException($"Запрос погоды для города '{cityName}' запрещен.");
        var weather = await weatherApi.GetWeatherApiAsync(cityName);
        return weather.GetDisplayInfo();
    }
}