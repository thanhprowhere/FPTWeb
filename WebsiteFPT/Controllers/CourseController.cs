using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Common;
using WebsiteFPT.Controllers;

namespace WebsiteFPT.Controllers
{
    public class CourseController : BaseController
    {
        // GET: Staff/Course
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var course = new ManagerCourse();
            var model = course.ListAllPaging(searchString, page, pageSize);
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
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                var managercourse = new ManagerCourse();
                long id = managercourse.Insert(course);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                    ModelState.AddModelError("", "Add user access");
                }
            }
            return View("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ManagerTopics();
            ViewBag.IdTopic = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        public void SetViewBag2(long? selectedId = null)
        {
            var dao = new CategoryCourseDao();
            ViewBag.IdCategoryCourse = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ManagerCourse().Delete(id);
            return RedirectToAction("Index");
        }

    }
}