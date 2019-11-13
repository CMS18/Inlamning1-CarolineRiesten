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
                 Name = "Kalle Lind"
            },

                new Customer()
            {
                 CustomerId = 2,
                 Name = "Fia Persson"
            },

                   new Customer()
            {
                 CustomerId = 3,
                 Name = "Challe Klasson"
            }
        };
    }
}
