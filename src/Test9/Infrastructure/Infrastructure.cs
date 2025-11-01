using System.Text.Json;
using Application;

namespace Infrastructure;

public class HttpRequest(HttpClient client)
{
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";
    private static readonly string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public async Task GetResponseAsync(string cityName)
    {
        var url = $"{BaseUrl}?q={cityName}&appid={ApiKey}&units=metric&lang=ru";
        var responseMessage = await client.GetAsync(url);
        var responseJson = await responseMessage.Content.ReadAsStringAsync();
        var optionJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var weatherJsonResponse = JsonSerializer.Deserialize<WeatherJsonResponce>(responseJson, optionJson);
        var weatherInfo = new WeatherInfo(weatherJsonResponse);
        weatherInfo.PrintWeatherInfo();
    }
}