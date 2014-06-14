using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TodoWebApplication.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection Frm)
        {
            if (Frm["secretcode"] != null && Frm["secretcode"].ToString() == DateTime.Now.ToString("yyyyMMdd"))
            {
                FormsAuthentication.RedirectFromLoginPage("rmin", false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogOn", "Account");
        }
    }
}
