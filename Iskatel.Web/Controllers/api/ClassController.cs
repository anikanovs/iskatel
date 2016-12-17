using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Iskatel.DataAccess.Intefaces;
using Iskatel.Model;
using System.Web.Http;
using System.Web.Http.Results;

namespace Iskatel.Web.Controllers.api
{
    public class ClassController : ApiController
    {
        private IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        public JsonResult<List<KBSimpleType>> Get()
        {
            var model = _classService.GetKBSimpleTypeList();
            return Json(model);
        }

        public string Post(KBSimpleType entity) {
            _classService.UpdateKBSimpleType(entity);
            return "OK";
        }

        public string Put(KBSimpleType entity)
        {
            _classService.AddKBSimpleType(entity.Name, entity.Alias);
            return "OK";
        }

        public string Delete(int id)
        {
            _classService.DeleteKBSimpleType(id);
            return "OK";
        }
    }
}