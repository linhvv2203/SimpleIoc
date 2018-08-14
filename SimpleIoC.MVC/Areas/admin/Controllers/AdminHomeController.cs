using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleIoC.MVC.Areas.admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: admin/Home
        public ActionResult Index()
        {
            return View();
        }

    }
}