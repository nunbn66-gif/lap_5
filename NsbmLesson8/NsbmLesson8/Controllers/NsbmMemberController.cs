using Microsoft.AspNetCore.Mvc;
using NsbmLesson8.Models;

namespace NsbmLesson8.Controllers
{
    public class NsbmMemberController : Controller
    {
        private static List<NsbmMember> _member = new List<NsbmMember>()
        {
            new NsbmMember{NsbmMemberId=Guid.NewGuid().ToString(),NsbmUserName="Minh",NsbmPassword="123",NsbmFullName="Nguyen Sinh Binh Minh",NsbmEmail="Minh@nsbm.lk"},
             new NsbmMember{NsbmMemberId=Guid.NewGuid().ToString(),NsbmUserName="admin",NsbmPassword="admin",NsbmFullName="Admin User",NsbmEmail="admin@nsbm.lk"},
              new NsbmMember{NsbmMemberId=Guid.NewGuid().ToString(),NsbmUserName="admin",NsbmPassword="admin",NsbmFullName="Admin User",NsbmEmail="admin@nsbm.lk"},
               new NsbmMember{NsbmMemberId=Guid.NewGuid().ToString(),NsbmUserName="admin",NsbmPassword="admin",NsbmFullName="Admin User",NsbmEmail="admin@nsbm.lk"}
        };
        // get : danh sach thanh vien

        public IActionResult Index()
        {
            return View(_member);
        }
        [HttpGet]
        public IActionResult NsbmCreate()
        {
            var member = new NsbmMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult NsbmCreate(NsbmMember nsbmMember)
        {
            nsbmMember.NsbmMemberId = Guid.NewGuid().ToString();
            _member.Add(nsbmMember);
            return RedirectToAction("Index");
            //return View(nsbmMember);
        }
        [HttpGet]
        public IActionResult NsbmEdit(string id)
        {
            var member = _member.Where(x => x.NsbmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public IActionResult NsbmEdit(String id, NsbmMember nsbmMember)

        {
            // var member = _member.Where(x => x.NsbmMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _member.Count; i++)
            {
                if (_member[i].NsbmMemberId == id)
                {
                    _member[i].NsbmUserName = nsbmMember.NsbmUserName;
                    _member[i].NsbmPassword = nsbmMember.NsbmPassword;
                    _member[i].NsbmFullName = nsbmMember.NsbmFullName;
                    _member[i].NsbmEmail = nsbmMember.NsbmEmail;
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult NsbmDetails(string id)
        {
            var member = _member.Where(x => x.NsbmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpGet]
        public IActionResult NsbmDelete(string id)
        {
            var member = _member.Where(x => x.NsbmMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public IActionResult NsbmDelete(string id, NsbmMember nsbmMember)
        {
            foreach (var item in _member)
            {
                if (item.NsbmMemberId.Equals(id))
                {
                    _member.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
