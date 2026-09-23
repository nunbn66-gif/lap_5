using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NsbmLesson9.Models.DataModels;

namespace NsbmLesson9.Controllers
{
    public class NsbmMemberController : Controller
    {
        private static List<NsbmMember> _members = new List<NsbmMember>();
        // GET: NsbmMemberController
        public ActionResult Index()
        {
            return View(_members);
        }

        // GET: NsbmMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NsbmMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NsbmMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NsbmMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NsbmMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NsbmMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NsbmMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
