using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFPT.Areas.Admin.Models;
using WebsiteFPT.Common;

namespace WebsiteFPT.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModels model)
        {

            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[WebsiteFPT.Common.CommonConstants.USER_SSESION];

                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result)
                {
                    var user = dao.GetByID(model.UserName);
                    if (user.IdRole == 1)
                    {
                        var userSession = new UserLogin();
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.ID;
                        Session.Add(CommonConstants.USER_SSESION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account is not valid");
                }
            }
            return View("Index");
        }

    }
}