namespace Infrastructure;

public sealed record WeatherJsonResponse(Main Main, Wind Wind, string? Name, WeatherResponse[] Weather);