using System;
using System.ComponentModel.DataAnnotations;

namespace CarolinesBank.Data
{
    public class Account
    {
        [Range(1, 10, ErrorMessage ="Only integers between 1 - 10" )]
        public int AccountId { get; set; }
     
        public decimal Balance { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
