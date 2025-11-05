using AdminFE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminFE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult SearchUser()
        {
            return View();
        }

        public IActionResult SearchAccount()
        {
            return View();
        }

        public IActionResult UpdateAdmin()
        {
            return View();
        }

        public IActionResult DisplayAudits()
        {
            return View();
        }

        public IActionResult DisplayTransactions()
        {
            return View();
        }


        public IActionResult DeactivateUser()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult AdminDash()
        {
            return View();
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
