using Application;

namespace Infrastructure;

public class WeatherRequestValidator(IWeatherApi weatherApi)
{
    private readonly HashSet<string> _bannedCities = new(StringComparer.OrdinalIgnoreCase)
    {
        "Кишинев", "N", "Киев"
    };

    public async Task GetWeatherAsync(string cityName)
    {
        if (_bannedCities.Contains(cityName))
            throw new InvalidOperationException($"Запрос погоды для города '{cityName}' запрещен.");

        WeatherInfo weather = await weatherApi.GetAsync(cityName);
        var weatherInfo = weather.GetDisplayInfo();
        Console.WriteLine(weatherInfo);
    }
}