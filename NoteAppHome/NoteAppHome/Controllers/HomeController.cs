using Microsoft.AspNetCore.Mvc;
using NoteAppHome.Models;
using System.Diagnostics;

namespace NoteAppHome.Controllers
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
            string username = HttpContext.Session.GetString("email");
            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.Username = username;
            }

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