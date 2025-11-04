namespace Application;

public sealed class WeatherInfo
{
    private readonly string _cityName;
    private readonly double _temp;
    private readonly string _weather;
    private readonly double _windSpeed;

    public WeatherInfo(WeatherJsonResponce? data)
    {
        _cityName = data.Name;
        _weather = data.Weather[0].Description;
        _temp = data.Main.temp;
        _windSpeed = data.Wind.speed;
    }
    public WeatherInfo(string cityName, string weather, double temp, double windSpeed)
    {
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