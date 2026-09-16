using Microsoft.AspNetCore.Mvc;
using NsbmLesson8.Models;
using System.Diagnostics;

namespace NsbmLesson8.Controllers
{
    public class NsbmHomeController : Controller
    {
        private readonly ILogger<NsbmHomeController> _logger;
        public IActionResult NsbmIndex()
        {
            return View();
        }

        public IActionResult NsbmPrivacy()
        {
            return View();
        }
        public IActionResult NsbmAbout()
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
