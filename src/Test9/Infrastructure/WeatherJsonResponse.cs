namespace Infrastructure;

public sealed record WeatherJsonResponse(TempInfoDto Main, WindInfoDto Wind, string? Name, WeatherResponseInfoDto[] Weather);