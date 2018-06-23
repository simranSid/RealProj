using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using realProject.Models;

namespace realProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
		
		[HttpPost]
		public ActionResult Index(Login lg)
		{
			Login lgonj = new Login();
			if (lgonj.Validate(lg.Username,lg.password))
			{
				FormsAuthentication.SetAuthCookie("usernameCookie", false);
				Session["Login"] = lg.Username;
				return RedirectToAction("Index", "Home");
			}
			
			return View();

		}
		public ActionResult Logout()
		{
			if (Session["Login"] != null)
			{
				Session["Login"] = null;
				Session.Abandon();
				Session.Clear();
				FormsAuthentication.SignOut();
			}
			return View("Index");
		}

	}
}