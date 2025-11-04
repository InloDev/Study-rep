using Infrastructure;

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException("Недопустимое название города!");

    IWeatherApi weatherApi = new WeatherApi(new HttpClient());
    var weather = await weatherApi.GetAsync(cityName);
    var weatherInfo = weather.GetDisplayInfo();
    Console.WriteLine(weatherInfo);
}
catch (ArgumentException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}