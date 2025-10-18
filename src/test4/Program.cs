var flag = 'Y';
while (flag is 'Y' or 'y')
{
    Console.Write("Введите 1-е число: ");
    var a = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите 2-е число: ");
    var b = Convert.ToInt32(Console.ReadLine());
    Console.Write("Выберите операцию (+, -, *, /): ");
    var c = Convert.ToChar(Console.ReadLine() ?? string.Empty);
    switch (c)
    {
        case '+': Console.WriteLine($"{a} + {b} = {a + b}"); break;
        case '-': Console.WriteLine($"{a} - {b} = {a - b}"); break;
        case '*': Console.WriteLine($"{a} * {b} = {a * b}"); break;
        case '/': Console.WriteLine($"{a} / {b} = {a / b}"); break;
    }

    Console.WriteLine("Желаете продолжить? (Y/N)");
    flag = Convert.ToChar(Console.ReadLine() ?? string.Empty);
}