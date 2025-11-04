namespace Application;

public sealed class WeatherInfo
{
    private readonly string _cityName;
    private readonly double _temp;
    private readonly string _weather;
    private readonly double _windSpeed;

    public WeatherInfo(string cityName, string weather, double temp, double windSpeed)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cityName);
        ArgumentException.ThrowIfNullOrWhiteSpace(weather);
        ArgumentOutOfRangeException.ThrowIfNegative(windSpeed);
        
        _cityName = cityName;
        _weather = weather;
        _temp = temp;
        _windSpeed = windSpeed;
    }

    public string GetDisplayInfo()
    {
        return $"Город: {_cityName}\nПогода: {_weather}\nТемпература: {_temp} °C\nСкорость ветра: {_windSpeed} м/с";
    }
}