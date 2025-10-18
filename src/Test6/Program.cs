/*
6. Класс “Банк / Счёт”
Класс BankAccount с балансом.
Методы:

* Deposit() — пополнить
* Withdraw() — снять (если хватает средств)
* Transfer() — перевести на другой счёт
  Баланс не может быть отрицательным.
*/

var account1 = new BankAccount(00001, 250);
account1.Deposit(1000);
account1.Withdraw(1100);

var account2 = new BankAccount(00002);
account1.Transfer(account2, 100);
account1.Transfer(account2, 100);
account2.Print();

internal class BankAccount
{
    private readonly int _id;
    private int _balance;

    public BankAccount(int id)
    {
        _id = id;
        _balance = 0;
    }

    public BankAccount(int id, int balance)
    {
        _id = id;
        if (balance > 0)
            _balance = balance;
    }

    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Счет пополнен на {amount}. Остаток на счете: {_balance} ");
        }
    }

    public void Withdraw(int amount)
    {
        if (amount > 0 || _balance - amount > 0)
        {
            _balance -= amount;
            Console.WriteLine($"С счета снято {amount}. Остаток на счете: {_balance}");
        }
        else
        {
            Console.WriteLine("Не удалось снять средсва. Недостаточно средств.");
        }
    }

    public void Transfer(BankAccount bankAccount, int amount)
    {
        if (_balance - amount > 0)
        {
            _balance -= amount;
            bankAccount.Deposit(amount);
            Console.WriteLine($"На счет {bankAccount._id} переведенно {amount}");
        }
        else
        {
            Console.WriteLine("Не удалось перевести средства. Недостаточно средств.");
        }
    }

    public void Print()
    {
        Console.WriteLine($"Остаток на счете: {_balance}");
    }
}