using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMainService _MainService;

        public HomeController(IMainService mainService)
        {
            _MainService = mainService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Source(int id)
        {
            return View(_MainService.GetSource(id));
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