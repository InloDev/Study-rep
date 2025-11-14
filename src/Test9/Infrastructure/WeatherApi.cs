using Application;

namespace Infrastructure;

public sealed class WeatherApi(IOpenWeatherApi api) : IWeatherApi
{
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";

    public async Task<WeatherInfo> GetAsync(string cityName)
    {
        var weatherResponse = await api.GetWeatherAsync(cityName, ApiKey);
        if (weatherResponse is null)
            throw new InvalidOperationException("Не удалось получить данные о погоде");

        var weatherInfo = new WeatherInfo(
            weatherResponse.Name ??
            throw new InvalidOperationException("Не удалось получить информацию о погоде для указанного города."),
            weatherResponse.Weather[0].Description,
            weatherResponse.Main.Temp, weatherResponse.Wind.Speed);
        return weatherInfo;
    }
}