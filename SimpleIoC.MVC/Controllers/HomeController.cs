using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SimpleIoC.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private Cart _cart;

        public HomeController(Cart cart)
        {
            _cart = cart;
        }
        //[OutputCache(Duration = 10,VaryByParam ="none",Location =OutputCacheLocation.Server)]
        public ActionResult Index()
        {

            throw new Exception("this is unhandle exception");
            //_cart.Checkout(1, 91);
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}