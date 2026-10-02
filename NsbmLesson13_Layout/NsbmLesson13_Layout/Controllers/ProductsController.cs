using Microsoft.AspNetCore.Mvc;

namespace NsbmLesson13_Layout.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string keyword)
        {
            ViewData["ProductId"] = keyword;
            return View();
        }
        public IActionResult Hots()
        {
            return View();
        }
    }
}
