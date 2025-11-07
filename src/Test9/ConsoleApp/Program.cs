using Infrastructure;

try
{
    Console.Write("Напишите название города: ");
    var cityName = Convert.ToString(Console.ReadLine());

    if (string.IsNullOrWhiteSpace(cityName)) throw new ArgumentException("Недопустимое название города!");

    IWeatherApi weatherApi = new WeatherApi(new HttpClient());
    BannedCitiesCheck check = new BannedCitiesCheck(weatherApi); 
    await check.GetWeatherAsync(cityName);
   
}
catch (ArgumentException e)
{
    Console.WriteLine($"Ошибка: {e.Message}");
}