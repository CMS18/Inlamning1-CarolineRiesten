using CarolinesBank.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarolinesBank.Webb.ViewModels
{
    public class AccountViewModel
    {
       [Display(Name = "Belopp" )]
       [Range(0.01, 9999999.99, ErrorMessage ="The amount must be between 0.01 - 9 999 999,99")]
        public decimal Amount { get; set; }
        //[Remote("VerifyEmail", "Account")]
        public Account CurrentAccount { get; set; }

        public string Action { get; set; }

    }
}
