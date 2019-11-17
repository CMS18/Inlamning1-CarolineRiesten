using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarolinesBank.Data;
using CarolinesBank.Webb.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace CarolinesBank.Webb.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository repo;
        private readonly TransferViewModel vm;
        public TransferController(BankRepository repo)
        {
            this.repo = repo;
            this.vm = new TransferViewModel();
        }
        public IActionResult Index()
        {
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HandleTransfer(TransferViewModel vm)
        {
            var fromAccount = repo.FindAccount(vm.FromAccountId);
            if (fromAccount == null)
            {
                ViewBag.Message = "The account doesn't exist";
                return View("Index");
            }
            else
            {
                var toAccount = repo.FindAccount(vm.ToAccountId);
                if (toAccount == null)
                {
                    ViewBag.Message = "The account doesn't exist";
                    return View("Index");
                }
                else
                {
                    //TODO: koll för minusbelopp och för höga belopp
                    //använda redan skriven kod?
                    //antagligen för många if satser i varann, Göra try-catch istället?
                }
            }
        }
    }
}
