using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;

namespace WebsiteFPT.Controllers
{
    public class CategoryCourseController : Controller
    {
        // GET: Staff/CategoryCourse
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var category = new CategoryCourseDao();
            var model = category.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseCategory coursecategory)
        {
            if (ModelState.IsValid)
            {
                var coursecategorydao = new CategoryCourseDao();
                long id = coursecategorydao.Insert(coursecategory);
                if (id > 0)
                {
                    return RedirectToAction("Index", "CategoryCourse");
                }
                else
                {
                    ModelState.AddModelError("", "Add CategoryCourse access");
                }
            }
            return View("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryCourseDao();
            ViewBag.IdCategoryCourse = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryCourseDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}