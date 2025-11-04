namespace Application;

public sealed class WeatherJsonResponce
{
    public Weather[] Weather { get; set; }
    public Main Main { get; set; }
    public Wind Wind { get; set; }
    public string Name { get; set; }
}

public sealed class Weather
{
    public string Main { get; set; }
    public string Description { get; set; }
}