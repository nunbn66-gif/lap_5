using Microsoft.AspNetCore.Mvc;
using NguyenSinhBinhMinh_2410900053_exam.Models;
using System.Diagnostics;

namespace NguyenSinhBinhMinh_2410900053_exam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
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
