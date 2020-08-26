using Microsoft.AspNet.Identity;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Areas.Admin.Models;
using WebsiteFPT.Common;
using WebsiteFPT.Models;

namespace WebsiteFPT.Controllers
{
    public class StudentViewController : BaseController
    {
        WebsiteFPTDbContext db = null;
        public StudentViewController()
        {
            db = new WebsiteFPTDbContext();
        }

        public ActionResult Index(LoginModels model)
        {
            var dao = new UserDao();
            var result = dao.Login(model.UserName, model.Password);
            if (result)
            {
                var userSession = new UserLogin();
                var user = dao.GetByID(model.UserName);
                userSession.UserID = user.ID;
                Session.Add(CommonConstants.USER_SSESION, userSession);
                var viewModel = new ViewModels
                {
                    enrollments = db.Enrollments.Where(s => s.IdUser == userSession.UserID)
                    .ToList(),
                    courses = db.Courses.ToList()
                };

                return View(viewModel);
            }

            return View();
        }

    }
}