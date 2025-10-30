/*
6. Класс “Банк / Счёт”
Класс BankAccount с балансом.
Методы:

* Deposit() — пополнить
* Withdraw() — снять (если хватает средств)
* Transfer() — перевести на другой счёт
  Баланс не может быть отрицательным.
*/

using Test6;

var account1 = new BankAccount(10001, 250);
account1.Deposit(1000);
account1.Withdraw(1100);

var account2 = new BankAccount(10002);
account1.Transfer(account2, 100);
account1.Transfer(account2, 100);
account2.Print();