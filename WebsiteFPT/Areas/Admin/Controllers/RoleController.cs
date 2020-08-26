using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Models.EF;
using WebsiteFPT.Areas.Admin.Controllers;

namespace WebsiteFPT.Areas.Staff.Controllers
{
    public class RoleController : BaseController
    {
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var role = new ManagerRole();
            var model = role.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                var managerrole = new ManagerRole();
                long id = managerrole.Insert(role);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Role");
                }
                else
                {
                    ModelState.AddModelError("", "Add role access");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ManagerRole().Delete(id);
            return RedirectToAction("Index");
        }

    }
}