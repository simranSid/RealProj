using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using realProject.Models;

namespace realProject.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Login lg)
		{
			Login lgonj = new Login();
			lgonj.Register(lg.Username, lg.password);
			return RedirectToAction("Index","Login");
		}
	}
}