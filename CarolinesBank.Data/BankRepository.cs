﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarolinesBank.Data
{
    public class BankRepository
    {
        public List<Customer> listOfCustomers { get; set; } = new List<Customer>()
        {
             new Customer()
            {
                 CustomerId = 1,
                 Name = "Kalle Lind",
                 CustomerAccounts = new List<Account>()
                 {
                     new Account
                     {
                         AccountId = 1,
                         Balance = 234
                     },
                     new Account
                     {
                         AccountId = 2,
                         Balance = 20
                     }
                 }

            },

                new Customer()
            {
                 CustomerId = 2,
                 Name = "Fia Persson",
                 CustomerAccounts = new List<Account>()
                 {
                     new Account
                     {
                         AccountId = 3,
                         Balance = 34
                     },
                     new Account
                     {
                         AccountId = 4,
                         Balance = 20
                     }
                 }
            },

                   new Customer()
            {
                 CustomerId = 3,
                 Name = "Challe Klasson",
                 CustomerAccounts = new List<Account>()
                 {
                     new Account
                     {
                         AccountId = 5,
                         Balance = 2000
                     },
                     new Account
                     {
                         AccountId = 6,
                         Balance = 203
                     }
                 }
            }
        };

        public Account WithDraw(int id, decimal amount)
        {
            var currentAccount = FindAccount(id);
         
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "the withrawel can not be a negative number");
                }
         
                if (currentAccount.Balance - amount < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "the withrawel can not be more than the balance");
                }
       
            currentAccount.Balance -= amount;

            return currentAccount;
        }

        public List<Customer> getAllCustomers()
        {
            return listOfCustomers;
        }

        public void DepositFromAccount(Account from, Account to, decimal amount)
        {
            if (from.Balance < amount) throw new ArgumentOutOfRangeException(nameof(amount),
                 "No coverage for this transfer");
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount),
                "Amount can not be negative");
            else
            {
                from.Balance -= amount;
                to.Balance += amount;
            }
        }

        public Account Deposit(int id, decimal amount)
        {
            var currentAccount = FindAccount(id); // programmera för success kasta felmeddelanden

            if (amount < 0)
            {
                currentAccount.Success = false;

            }
            else
            {
                currentAccount.Balance += amount;
                currentAccount.Success = true;
            }

            return currentAccount;
 
        }






        public Account FindAccount(int id)
        {
            var listofAccount = new List<Account>();
            foreach (var a in listOfCustomers)
            {
                listofAccount.AddRange(a.CustomerAccounts);
            }
            var currentAccount = listofAccount.Find(a => a.AccountId == id);

            return currentAccount;
        }
    }
}
