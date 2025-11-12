namespace Infrastructure;

public sealed class CityRestrictionService(IWeatherApi weatherApi) : ICityRestrictionService
{
    private readonly HashSet<string> _bannedCities = new(StringComparer.OrdinalIgnoreCase)
    {
        "Кишинев", "N", "Киев"
    };

    public async Task<string> GetWeatherAsync(string cityName)
    {
        if (_bannedCities.Contains(cityName))
            throw new InvalidOperationException($"Запрос погоды для города '{cityName}' запрещен.");

        return (await weatherApi.GetAsync(cityName)).GetDisplayInfo();
    }
}