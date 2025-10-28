using System.Text.Json;

namespace Test9;

public interface IWeatherResponse
{
    Task<OpenWeatherResponse?> GetWeatherAsync(string cityName);
}
public abstract class Infrastructure() : IWeatherResponse
{
    private readonly HttpClient _client = new HttpClient();
    private readonly string _apiKey = "65eed83ce86219a7eba772b95cccf376";

   /* public Infrastructure(string? apiKey)
    {
        if (apiKey is not null)
        {
            this._apiKey = apiKey;
        }   
    }*/
   
    public async Task<OpenWeatherResponse?> GetWeatherAsync(string cityName)
    {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={_apiKey}";
            var response = await _client.GetStringAsync(url);
            var weather = JsonSerializer.Deserialize<OpenWeatherResponse>(response);
            return weather;
    }
}