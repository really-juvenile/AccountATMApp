using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AccountApp.Models;

namespace AccountApp
{
    internal class Program
    {
        static void Main(string[] args)
        {




            //Account account1 = new Account(101, "Allen");
            //Account account2 = new Account(102, "Mary", 5000);


            Account[] accounts = new Account[] {
                new Account(101,"Allen"),
                new Account(102,"Mary")
            };



            //Deposit(account1, 1500);
            //Withdraw(account1, 1700);
            //Deposit(account2, 1000);
            //Withdraw(account2, 1500);


            DisplayMainMenu(accounts);

            //Console.WriteLine(account1);
            //Console.WriteLine(account2);


            //Account maxAccount = Account.AccountWithMaxBalance(accounts);
            //Console.WriteLine("\nAccount with max balance is : ");
            //Console.WriteLine(maxAccount);

        }

        static void DisplayMainMenu(Account[] accounts)
        {
            Account accountInUse = null;
            Console.WriteLine("============welcome to account management APP==============\n");
            Console.WriteLine("Please Enter your account no. ");
            int accountNo = Convert.ToInt32(Console.ReadLine());

            foreach (Account account in accounts)
            {

                if (account.AccountNumber == accountNo)
                {
                    accountInUse = account;
                }
            }
            Console.WriteLine($"\n Welcome {accountInUse.Name} \n");

            while (true)
            {

                Console.WriteLine($"What do you wish to do? \n" +
                    $"1. Deposit\n 2.Withdraw \n3.Check details \n4.Exit \nEnter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());

                DoTask(accountInUse, choice);

            }

        }

        static void DoTask(Account accountInUse, int choice)
        {
            double amount;
            switch (choice)
            {
                case 1:
                    amount = GetAmount();
                    Deposit(accountInUse, amount);
                    break;

                case 2:
                    amount = GetAmount();
                    Withdraw(accountInUse, amount);
                    break;

                case 3:
                    Console.WriteLine(accountInUse);
                    break;

                case 4:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter valid Input");
                    break;
            }


        }


        static double GetAmount()
        {
            Console.WriteLine("Enter Amount: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static void Deposit(Account account, double amount)
        {
            account.Deposit(amount);
            Console.WriteLine($"amount of Rs. {amount} deposited in account {account.AccountNumber} successfully\n" +
                $"Update Balance is: {account.Balance} ");

            Console.WriteLine("==============================================");

        }


        static void Withdraw(Account account, double amount)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"amount of Rs. {amount} withdraw from account {account.AccountNumber}\n" +
                    $"Successfully \nupdated balance is: {account.Balance}");

                Console.WriteLine("======================================");


            }
            else
            {
                Console.WriteLine("Insufficient Account Balance !! Withdrawl Denied");
                Console.WriteLine("=============================================");
            }

        }

    }
}
