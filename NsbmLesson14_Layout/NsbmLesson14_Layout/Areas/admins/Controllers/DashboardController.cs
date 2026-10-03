using Microsoft.AspNetCore.Mvc;

namespace NsbmLesson14_Layout.Areas.admins.Controllers
{
    [Area("Admins")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
