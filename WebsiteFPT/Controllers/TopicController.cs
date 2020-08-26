using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Models.EF;

namespace WebsiteFPT.Controllers
{
    public class TopicController : BaseController
    {
        // GET: Staff/Topic
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var topic = new ManagerTopics();
            var model = topic.ListAllPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                var managertopic = new ManagerTopics();
                long id = managertopic.Insert(topic);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Topic");
                }
                else
                {
                    ModelState.AddModelError("", "Add topic access");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ManagerTopics().Delete(id);
            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ManagerCourse();
            ViewBag.IdCourse = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}