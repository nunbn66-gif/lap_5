using Microsoft.AspNetCore.Mvc;
using NsbmLesson7.Models.DataModels ;
namespace NsbmLesson7.Controllers
{
    public class NsbmMemberController : Controller
    {
        protected static List<NsbmMember> _members = new List<NsbmMember>
                {
                        new NsbmMember
                    {
                        NsbmMemberId = "MB001",
                        NsbmUserName = "nguyenvana",
                        NsbmPassword = "Password123!",
                        NsbmFullName = "Nguyễn Văn A",
                        NsbmEmail = "nguyenvana@gmail.com"
                    },
                    new NsbmMember
                    {
                        NsbmMemberId = "MB002",
                        NsbmUserName = "tranthib",
                        NsbmPassword = "Password456!",
                        NsbmFullName = "Trần Thị B",
                        NsbmEmail = "tranthib@gmail.com"
                    },
                    new NsbmMember
                    {
                        NsbmMemberId = "MB003",
                        NsbmUserName = "levanc",
                        NsbmPassword = "Password789!",
                        NsbmFullName = "Lê Văn C",
                        NsbmEmail = "levanc@gmail.com"
                    }
                };
        public IActionResult Index()
        {

            return View(_members);
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
           // ViewBag.Member = member;
            return View(member);
        }
        // đưa dữ liệu dạng list ra view
        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Post: create member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NsbmMember member)
        {
            // Tạo ID trước khi kiểm tra Validation
            member.NsbmMemberId = Guid.NewGuid().ToString();
            ModelState.Remove("NsbmMemberId"); // Loại bỏ NsbmMemberId khỏi danh sách kiểm tra lỗi null

            if (ModelState.IsValid)
            {
                _members.Add(member);
                return RedirectToAction(nameof(GetMembers)); // Hoặc RedirectToAction("GetMembers") tùy View hiển thị danh sách của bạn
            }
            return View(member);
        }
    }
}
