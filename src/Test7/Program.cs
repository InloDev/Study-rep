using System.Text;

namespace Test7;

internal abstract class Program
{
    private static void Main()
    {
        Console.WriteLine("Генератор паролей");

        // Запрос длины пароля
        Console.Write("Введите длину пароля: ");
        int length;
        while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
            Console.Write("Пожалуйста, введите положительное число: ");

        // Настройки
        var useLetters = AskForOption("Использовать буквы? (y/n): ");
        var useDigits = AskForOption("Использовать цифры? (y/n): ");
        var useSpecialChars = AskForOption("Использовать специальные символы? (y/n): ");

        // Генерация пароля
        var password = GeneratePassword(length, useLetters, useDigits, useSpecialChars);
        Console.WriteLine($"Сгенерированный пароль: {password}");
    }

    private static bool AskForOption(string message)
    {
        Console.WriteLine(message);
        var response = Console.ReadKey().KeyChar;
        return response is 'y' or 'Y';
    }

    private static string GeneratePassword(int length, bool useLetters, bool useDigits, bool useSpecialChars)
    {
        var password = new StringBuilder();
        var chars = "";

        if (useLetters)
            chars += "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (useDigits)
            chars += "0123456789";
        if (useSpecialChars)
            chars += "!@#$%^&*()-_=+[]{};:,.<>?";

        if (string.IsNullOrEmpty(chars))
            throw new ArgumentException("Не выбраны ни одни символы для генерации пароля.");

        var random = new Random();
        for (var i = 0; i < length; i++)
        {
            var index = random.Next(chars.Length);
            password.Append(chars[index]);
        }

        return password.ToString();
    }
}