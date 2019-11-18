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
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Något gick fel, var god försök igen";
                return View("Index");
            }

            var fromAccount = repo.FindAccount(vm.FromAccountId);
            var toAccount = repo.FindAccount(vm.ToAccountId);
            if (fromAccount == null || toAccount == null)
            {
                ViewBag.Message = "Invalid AccountId";
                return View("Index");
            }

            try
            {
                repo.DepositFromAccount(fromAccount, toAccount, vm.Amount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ViewBag.Message = ex.Message;
                return View("Index");
            }

            vm.NewBalanceFrom = fromAccount.Balance;
            vm.NewBalanceTo = toAccount.Balance;
            return View("TransferFeedBack", vm);
        }
    }
}
