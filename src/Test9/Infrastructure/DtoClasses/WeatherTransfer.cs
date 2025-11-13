namespace Infrastructure;

public sealed record WeatherTransfer(TempInfoDto Main, WindInfoDto Wind, string? Name, WeatherInfoDto[] Weather);