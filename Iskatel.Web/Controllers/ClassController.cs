using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iskatel.DataAccess.Intefaces;
using Iskatel.Model;
using Iskatel.Web.Models;

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

        public ActionResult _SimpleTypeList()
        {
            var model = _classService.GetKBSimpleTypeList();
            return PartialView(model);
        }

        public ActionResult AddSimpleType(string typeName, string typeAlias)
        {
            _classService.AddKBSimpleType(typeName, typeAlias);
            return RedirectToAction("SimpleTypes");
        }

        public ActionResult Entities()
        {
            var model = _classService.GetKBEntityList();
            return View(model);
        }

        public ActionResult AddEntity(string name, string alias)
        {
            _classService.AddKBEntity(name, alias);
            return RedirectToAction("Entities");
        }

        public ActionResult EditEntity(int id)
        {
            ViewBag.Entity = _classService.GetKBEntity(id);
            var model = new AddKBEntityFieldModel() { KBEntityId = id };
            ViewBag.Types = _classService.GetKBSimpleTypeList();
            return View(model);
        }

        public ActionResult AddEntityField(AddKBEntityFieldModel model)
        {
            _classService.AddFieldToKBEntity(model.KBEntityId, model.Alias, model.Name, model.TypeId);
            return RedirectToAction("EditEntity", new { id = model.KBEntityId });
        }
    }
}