using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarolinesBank.Webb.Models;

namespace CarolinesBank.Webb.ViewModels
{
    public class TransferViewModel
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }

        [Display(Name = "Belopp")]
        [Range(0.01, 9999999.99, ErrorMessage = "The amount must be between 0.01 - 9 999 999,99")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public decimal NewBalanceFrom { get; set; }
        public decimal NewBalanceTo { get; set; }
    }
}
