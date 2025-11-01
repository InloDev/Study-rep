namespace Application;

public class WeatherInfo(WeatherJsonResponce? data)
{
    private string? CityName { get; } = data?.name;
    private string? Weather { get; } = data?.weather[0].description;
    private double? Temp { get; } = data?.main.temp;
    private double? WindSpeed { get; } = data?.wind.speed;

    public void PrintWeatherInfo()
    {
        Console.Write($"Город: {CityName}\nПогода: {Weather}\nТемпература: {Temp} °C\nСкорость ветра: {WindSpeed} м/с");
    }
}