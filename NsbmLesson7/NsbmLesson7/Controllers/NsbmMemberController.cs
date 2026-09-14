using Microsoft.AspNetCore.Mvc;
using NsbmLesson7.Models.DataModels ;
namespace NsbmLesson7.Controllers
{
    public class NsbmMemberController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult GetMember()
        {
            var member = new NsbmMember
            {
                NsbmMemberId = Guid.NewGuid().ToString(),
                NsbmUserName = "Nsbm",
                NsbmPassword = "password123",
                NsbmFullName = "Nguyen Sinh Binh Minh",
                NsbmEmail = "Binhminh@example.com"
            };
            ViewBag.Member = member;
            return View();
        }
    }
}
