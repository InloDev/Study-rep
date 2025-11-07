using Infrastructure;

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException("Недопустимое название города!");

    IWeatherApi weatherApi = new WeatherApi(new HttpClient());
    WeatherRequestValidator check = new WeatherRequestValidator(weatherApi);
    await check.GetWeatherAsync(cityName);
   
}
catch (ArgumentException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}