using Application;

namespace Infrastructure;

public sealed class WeatherApi(IOpenWeatherApi api) : IWeatherApi
{
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";

    public async Task<WeatherInfo> GetWeatherApiAsync(string cityName)
    {
        var weatherResponse = await api.GetOpenWeatherApiAsync(cityName, ApiKey);
        if (weatherResponse is null)
            throw new InvalidOperationException("Не удалось получить данные о погоде");
        if (weatherResponse.Weather.Length == 0)
            throw new InvalidOperationException("Не удалось получить описание погоды");

        var weatherInfo = new WeatherInfo(
            weatherResponse.Name!,
            weatherResponse.Weather[0].Description,
            weatherResponse.Main.Temp, weatherResponse.Wind.Speed);
        return weatherInfo;
    }
}