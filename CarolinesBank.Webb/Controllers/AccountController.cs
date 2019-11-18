using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarolinesBank.Data;
using CarolinesBank.Webb.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarolinesBank.Webb.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository repo;
        public AccountController(BankRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            var model = new AccountViewModel();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HandleSubmit (AccountViewModel model)
        {
            var isAccount = repo.FindAccount(model.CurrentAccount.AccountId);
            model.CurrentAccount = isAccount; 
            if (model.CurrentAccount == null) 
            {
               ViewBag.Message = "The account doesn't exist"; 
                return View("Index", model); 
            }

            if (ModelState.IsValid)
            {
                if (model.Action.Equals("Deposit"))
                {
                   var currentAccount = repo.Deposit(model.CurrentAccount.AccountId, model.Amount);

                    if (!currentAccount.Success)
                    {
                        ViewBag.Message = "The amount can not be a negative number";
                        model.CurrentAccount = currentAccount;
                        return View("Index",model);
                    }
                    else
                    {
                        ModelState.Clear();
                        model.CurrentAccount = currentAccount;
                        return View("Index", model);
                    }
                }
                else
                {
                    try
                    {
                        repo.WithDraw(model.CurrentAccount.AccountId, model.Amount);
                    }
                    catch(ArgumentOutOfRangeException ex) 
                    {
                        ViewBag.Message = ex.Message;                    
                        return View("Index", model);
                    }
            
                }
            }
            else
            {
                return View("Index", model);
            }
            ModelState.Clear();
            return View("Index",model);
        }

    }
}
