using Infrastructure;

Console.WriteLine("Напишите название города: ");
string? cityName = Convert.ToString(Console.ReadLine());
Console.WriteLine(cityName);
HttpRequest request = new HttpRequest(new HttpClient());
if (cityName != null) await request.GetResponseAsync(cityName);
