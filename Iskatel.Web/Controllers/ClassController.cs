using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iskatel.DataAccess.Intefaces;
using Iskatel.Model;

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

        public ActionResult AddEntity(string name)
        {
            _classService.AddKBEntity(name);
            return RedirectToAction("Entities");
        }

        public ActionResult EditEntity(int id)
        {
            var entity = _classService.GetKBEntity(id);
            var addField = new AddKBEntityFieldModel() { KBEntityId = id };
            var types = _classService.GetKBSimpleTypeList();
            var model = new EditEntityModel()
            {
                Entity = entity,
                AddFieldModel = addField,
                Types = types
            };
            return View(model);
        }

        public ActionResult AddEntityField(AddKBEntityFieldModel model)
        {
            _classService.AddFieldToKBEntity(model.KBEntityId, model.Name, model.TypeId);
            return RedirectToAction("EditEntity", new { id = model.KBEntityId });
        }
    }
}