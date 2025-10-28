namespace Test9;

public class OpenWeatherResponse
{
    public string? Name { get; set; } //city name
    public List<WeatherDescription>? Weather { get; set; }
    public double Temp { get; set; }
    public double WindSpeed { get; set; }

    public class WeatherDescription
    {
        public string? Description { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
    }
}