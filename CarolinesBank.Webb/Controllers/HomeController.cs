using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarolinesBank.Webb.Models;
using CarolinesBank.Data;
using CarolinesBank.Webb.ViewModels;

namespace CarolinesBank.Webb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankRepository repo; 
        public HomeController(ILogger<HomeController> logger, BankRepository repo)
        {
            _logger = logger;
            this.repo = repo; 
        }

        public IActionResult Index()
        {
            var model = new CustomersViewModel()
            {
                ListOfCurrentCustomers = repo.getAllCustomers()
            };
           
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
