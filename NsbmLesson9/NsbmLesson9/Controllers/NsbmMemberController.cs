using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using NsbmLesson9.Models.DataModels;
using NsbmLesson9.Models.DataViewModels;

namespace NsbmLesson9.Controllers
{
    public class NsbmMemberController : Controller
    {
        private static List<NsbmMember> _members = new List<NsbmMember>();

        // GET: Hiển thị danh sách
        public ActionResult Index()
        {
            return View(_members);
        }

        // GET: Xem chi tiết
        public ActionResult Details(int id)
        {
            var member = _members.FirstOrDefault(m => m.NsbmMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // GET: Form thêm mới
        public ActionResult Create()
        {
            return View();
        }

        // POST: Xử lý thêm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NsbmMemberRegister model)
        {
         
            ModelState.Remove("NsbmMemberId");
            ModelState.Remove("NsbmFullName");
            ModelState.Remove("NsbmBirthday");

            
            if (ModelState.IsValid)
            {
                var newMember = new NsbmMember
                {
                    NsbmMemberId = _members.Any() ? _members.Max(m => m.NsbmMemberId) + 1 : 1,
                    NsbmUserName = model.NsbmUserName,
                    NsbmPassword = model.NsbmPassword,
                    NsbmEmail = model.NsbmEmail,
                    NsbmPhoneNumber = model.NsbmPhoneNumber,

                    // Cấp giá trị mặc định cho các trường trống
                    NsbmFullName = model.NsbmFullName ?? "Chưa cập nhật",
                    NsbmBirthday = model.NsbmBirthday == default ? DateTime.Now : model.NsbmBirthday
                };

                _members.Add(newMember);
                return RedirectToAction(nameof(Index));
            }

            
            return View(model);
        }

        // GET: Form cập nhật
        public ActionResult Edit(int id)
        {
            var member = _members.FirstOrDefault(m => m.NsbmMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: Xử lý cập nhật
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NsbmMember model)
        {
            var existingMember = _members.FirstOrDefault(m => m.NsbmMemberId == id);
            if (existingMember != null)
            {
                existingMember.NsbmUserName = model.NsbmUserName;
                existingMember.NsbmPassword = model.NsbmPassword;
                existingMember.NsbmEmail = model.NsbmEmail;
                existingMember.NsbmPhoneNumber = model.NsbmPhoneNumber;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Form xác nhận xóa
        public ActionResult Delete(int id)
        {
            var member = _members.FirstOrDefault(m => m.NsbmMemberId == id);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: Xử lý xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var member = _members.FirstOrDefault(m => m.NsbmMemberId == id);
            if (member != null)
            {
                _members.Remove(member);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}