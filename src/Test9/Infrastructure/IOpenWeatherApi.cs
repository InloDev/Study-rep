using Refit;

namespace Infrastructure;

public interface IOpenWeatherApi
{
    [Get("/weather")]
    Task<WeatherTransfer> GetOpenWeatherApiAsync(
        [AliasAs("q")] string cityName,
        [AliasAs("appid")] string apiKey,
        [AliasAs("units")] string units = "metric",
        [AliasAs("lang")] string lang = "ru");
}