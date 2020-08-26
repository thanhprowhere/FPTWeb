using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebsiteFPT.Controllers
{
    public class EnrollmenController : Controller
    {
        // GET: Enrollmen
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var enroll = new EnrollmentDao();
            var model = enroll.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            SetViewBag2();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Enrollment enroll)
        {
            if (ModelState.IsValid)
            {
                var enrollmentdao = new EnrollmentDao();
                long id = enrollmentdao.Insert(enroll);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Enrollmen");
                }
                else
                {
                    ModelState.AddModelError("", "Add Course access");
                }
            }
            return View("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ManagerCourse();
            ViewBag.IdCourse = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        public void SetViewBag2(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.IdUser = new SelectList(dao.ListAll(), "ID", "UserName", selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new EnrollmentDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}