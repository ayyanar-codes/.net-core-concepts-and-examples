using dependency_injection_example.Models;
using dependency_injection_example.Services.Log;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dependency_injection_example.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            var services=this.HttpContext.RequestServices;
            var _logger = (ILog)services.GetService(typeof(ILog));
            _logger.Info("Index screen loaded by get service manually");
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
