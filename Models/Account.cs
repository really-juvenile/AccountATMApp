using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.Models
{
    internal class Account
    {



        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public string AdharNumber { get; set; }
        static int MIN_BALANCE = 500;


        public Account(int accountNo, string name)
        {
            AccountNumber = accountNo;
            Name = name;
            Balance = MIN_BALANCE;

        }


        public Account(int accountNumber, string name, double balance) : this(accountNumber, name)
        {

            if (balance < MIN_BALANCE)
            {
                Balance = MIN_BALANCE;

            }
            else
            {
                Balance = balance;
            }
        }

        public Account(int accno, string name, double balance, string aadhar) : this(accno, name, balance)
        {
            {
                AdharNumber = aadhar;
            }

        }

        public bool Deposit(double amount)
        {
            Balance += amount;
            return true;
        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount < MIN_BALANCE)
            {
                Console.WriteLine("insufficient balance");
                return false;
            }
            Balance -= amount;
            return true;
        }

        public static Account AccountWithMaxBalance(Account[] accounts)

        {

            Account accountwithMaxBalance = null; //accounts[0];
            double maxBalance = MIN_BALANCE;
            foreach (Account account in accounts)
            {

                if (account.Balance > maxBalance)
                {
                    maxBalance = account.Balance;
                    accountwithMaxBalance = account;

                }

            }
            return accountwithMaxBalance;


        }
        public override string ToString()
        {
            return $"============Account No. {AccountNumber}\n" +
                $"Account Holder name: {Name}\n" +
                $"Account BAlance: {Balance}";
        }



    }

}
