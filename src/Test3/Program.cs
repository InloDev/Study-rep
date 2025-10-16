Console.WriteLine("Отгадайте число!!! Игра начинается!!!");
var random = new Random();
var randomNumber = random.Next(0, 100);
while (true)
{
    Console.Write("Введите число: ");
    var userNumber = Convert.ToInt32(Console.ReadLine());
    if (userNumber == randomNumber)
    {
        Console.WriteLine("Ура Вы угадали загаданное число!!!");
        break;
    }

    if (userNumber < randomNumber) Console.WriteLine("Загаданное число больше");
    if (userNumber > randomNumber) Console.WriteLine("Загаданное число меньше");
}