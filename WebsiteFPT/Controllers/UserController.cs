using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using WebsiteFPT.Common;

namespace WebsiteFPT.Controllers
{
    public class UserController : BaseController
    {
        WebsiteFPTDbContext db = null;

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag1();
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encrytedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encrytedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add user access");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Update user access");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            db = new WebsiteFPTDbContext();
            var dao = from p in db.Roles where p.Name == "Trainee" select p;
            ViewBag.IdRole = new SelectList(dao.ToList(), "ID", "Name", selectedId);
        }
        public void SetViewBag1(long? selectedId = null)
        {
            var dao = new ManagerCourse();
            ViewBag.IdCourse = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}