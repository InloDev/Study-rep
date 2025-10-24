var repeatOperation = 'Y';
while (repeatOperation is 'Y' or 'y')
{
    Console.Write("Введите 1-е число: ");
    var firstNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите 2-е число: ");
    var secondNumber = Convert.ToInt32(Console.ReadLine());
    Console.Write("Выберите операцию (+, -, *, /): ");
    var selectionOperation = Convert.ToChar(Console.ReadLine() ?? string.Empty);
    switch (selectionOperation)
    {
        case '+': Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}"); break;
        case '-': Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}"); break;
        case '*': Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}"); break;
        case '/': Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}"); break;
    }

    Console.WriteLine("Желаете продолжить? (Y/N)");
    repeatOperation = Convert.ToChar(Console.ReadLine() ?? string.Empty);
}