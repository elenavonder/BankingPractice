using System;

namespace BankingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var acct1 = new Account("Checking");
            var acct2 = new Account("Savings for college");
            var acct3 = new Account("Savings for car");
            var acct4 = new Account("Savings for kids");
            acct1.print();
            acct3.Deposit(500);
            acct3.print();
            acct2.Withdraw(3);
            acct2.print();
            var success = Account.Transfer(100, acct3, acct1);
                if (success)
            {
                Console.WriteLine("Transfer worked");
            }
            else
            {
                Console.WriteLine("Transfer failed");
            }
            acct3.print();
            acct1.print();
        }
    }
}
