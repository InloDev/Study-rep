using System.Text.Json;
using Application;

namespace Infrastructure;

public sealed class WeatherApi(HttpClient client) : IWeatherApi
{
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public async Task<WeatherInfo> GetAsync(string cityName)
    {
        var url = $"{BaseUrl}?q={cityName}&appid={ApiKey}&units=metric&lang=ru";
        var responseMessage = await client.GetAsync(url);
        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        var optionJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var weatherJsonResponse = JsonSerializer.Deserialize<WeatherTransfer>(responseJson, optionJson);
        var weatherInfo = new WeatherInfo(
            weatherJsonResponse?.Name ??
            throw new InvalidOperationException("Не удалось получить информацию о погоде для указанного города."),
            weatherJsonResponse.Weather[0].Description,
            weatherJsonResponse.Main.Temp, weatherJsonResponse.Wind.Speed);
        return weatherInfo;
    }
}