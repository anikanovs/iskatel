using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.Web.Controllers
{
    public class ClassController : Controller
    {
        private IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }
        
        public ActionResult SimpleTypes()
        {
            var model = _classService.GetKBSimpleTypeList();
            return View(model);
        }

        public ActionResult AddSimpleType(string typeName)
        {
            _classService.AddKBSimpleType(typeName);
            return RedirectToAction("SimpleTypes");
        }

        public ActionResult Entities()
        {
            var model = _classService.GetKBEntityList();
            return View(model);
        }

        public ActionResult EditEntity(int id)
        {
            return View();
        }
    }
}