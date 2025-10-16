/* Обработка исключений при вводе
    Программа запрашивает число.

* Если введено не число → ошибка и повторный ввод
* Если число корректное → вывести его удвоенное значение
*/

while (true)
{
    Console.Write("Введите число: ");
    var input = Console.ReadLine();
    if (int.TryParse(input, out var number))
    {
        Console.WriteLine($"Удвоенное число: {number * number}");
        break;
    }

    Console.WriteLine("Ошибка ввода!");
}