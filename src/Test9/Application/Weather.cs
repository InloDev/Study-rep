namespace Application;

public class WeatherInfo(WeatherJsonResponce? data)
{
        private string? CityName { get; set; } = data?.name;
        private string? Weather { get; set; } = data?.weather[0].description;
        private double? Temp { get; set; } = data?.main.temp;
        private double? WindSpeed { get; set; } = data?.wind.speed;

        public void PrintWeatherInfo()
        {
                Console.Write($"Город: {CityName}\nПогода: {Weather}\nТемпература: {Temp} °C\nСкорость ветра: {WindSpeed} м/с");
        }
}
