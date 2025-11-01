namespace Application;

public sealed class WeatherInfo
{
    private readonly string? _cityName;
    private readonly double? _temp;
    private readonly string? _weather;
    private readonly double? _windSpeed;

    public WeatherInfo(WeatherJsonResponce? data)
    {
        _cityName = data?.name;
        _weather = data?.weather[0].description;
        _temp = data?.main.temp;
        _windSpeed = data?.wind.speed;
    }

    public WeatherInfo(string cityName, string weather, double temp, double windSpeed)
    {
        _cityName = cityName;
        _weather = weather;
        _temp = temp;
        _windSpeed = windSpeed;
    }

    public string PrintWeatherInfo()
    {
        return $"Город: {_cityName}\nПогода: {_weather}\nТемпература: {_temp} °C\nСкорость ветра: {_windSpeed} м/с";
    }
}