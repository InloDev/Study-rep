using System.Text.Json;
using Application;

namespace Infrastructure;

public class HttpRequest(HttpClient client)
{
    private static readonly string BaseUrl ="https://api.openweathermap.org/data/2.5/weather";
    private const string ApiKey = "65eed83ce86219a7eba772b95cccf376";

    public async Task GetResponseAsync(string cityName)
    {
        string url = $"{BaseUrl}?q={cityName}&appid={ApiKey}&units=metric&lang=ru";
        var responseMessage = await client.GetAsync(url);
        responseMessage.EnsureSuccessStatusCode();
        string responseJson = await responseMessage.Content.ReadAsStringAsync();
        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var weatherJsonResponse = JsonSerializer.Deserialize<WeatherJsonResponce>(responseJson,option);
        var weatherInfo = new WeatherInfo(weatherJsonResponse);
        weatherInfo.PrintWeatherInfo();
    }
}