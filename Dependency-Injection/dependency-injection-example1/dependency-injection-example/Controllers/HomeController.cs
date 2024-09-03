using dependency_injection_example.Models;
using dependency_injection_example.Services.Log;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dependency_injection_example.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly ILog _logger;

        public HomeController(ILog log)
        {
            _logger = log;
        }

        public IActionResult Index()
        {
            _logger.Info("Index screen loaded");
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
