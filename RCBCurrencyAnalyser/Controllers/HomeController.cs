using Microsoft.AspNetCore.Mvc;
using RCBCurrencyAnalyser.Helpers;
using RCBCurrencyAnalyser.Models;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml;

namespace RCBCurrencyAnalyser.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            //var xml = CbrAPIWorker.GetCurrencyCatalog(true);
            //var xmlToday = CbrAPIWorker.GetCurrencyDaily(DateTime.Today);
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}