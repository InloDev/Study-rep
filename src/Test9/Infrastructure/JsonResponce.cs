namespace Infrastructure;

public sealed class WeatherJsonResponce
{
    public WeatherJsonResponce(Main main, Wind wind, string? name)
    {
        this.main = main;
        this.wind = wind;
        this.name = name;
    }

    public WeatherResponse[] weather { get; set; } = Array.Empty<WeatherResponse>();
    public Main main { get; set; }
    public Wind wind { get; set; }
    public string? name { get; set; }
}