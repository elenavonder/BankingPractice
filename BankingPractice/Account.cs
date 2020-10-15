using System;
using System.Collections.Generic;
using System.Text;

namespace BankingPractice
{
    class Account
    {
        //Makes Id = 1
        private static int NextId = 1; 
        //private set keeps others from setting it
        public int Id { get; private set; } 
        public string Description { get; set; }
        //makes Balance = 0
        public double Balance { get; set; } = 0;

        //method to only have to type print to get ConsoleWriteline data
        public void print()
        {
            Console.WriteLine($"Id [{Id}], Desc[{Description}], Bal[{Balance}]" );
        }

        //transfer method using class methods to find before and after balance
        public static bool Transfer (double amount, Account FromAccount, Account ToAccount)
        {
            if(FromAccount == null || ToAccount == null)
            {
                return false;
            }
            if(amount <= 0)
            {
                return false;
            }
            var BeforeBalance = FromAccount.Balance;
            var AfterBalance = FromAccount.Withdraw(amount);
            if(BeforeBalance != AfterBalance + amount)
            {
                return false;
            }
            ToAccount.Deposit(amount);
            return true;
        }

        //Deposit method && cannot deposit a negative amount
        public double Deposit (double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cannot deposit negative amount");
            }
            Balance += amount;
            return Balance;
        }

        //Withdraw method && cannot withdraw more than is in the account
        public double Withdraw(double amount)
        {
            if (Balance < amount)
            {
                Console.WriteLine("Insufficient Funds");
                return Balance;
            }
            if(amount <= 0)
            {
                return Balance;
            }
            Balance -= amount;
            return Balance;
        }

        //constructor that generates a new Id for each column
        public Account (string description)
        {
            this.Id = NextId++;
            this.Description = description;
        }

        //default constructor
        public Account()
        {

        }
    }
}
