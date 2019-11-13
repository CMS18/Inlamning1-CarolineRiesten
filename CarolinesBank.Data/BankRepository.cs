using System;
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

        public List<Customer> getAllCustomers()
        {
            return listOfCustomers;
        }
    }
}
