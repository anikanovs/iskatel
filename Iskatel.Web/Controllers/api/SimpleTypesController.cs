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
    public class SimpleTypesController : ApiController
    {
        private ISimpleTypesService _simpleTypesService;

        public SimpleTypesController(ISimpleTypesService simpleTypesService)
        {
            _simpleTypesService = simpleTypesService;
        }

        public JsonResult<List<KBSimpleType>> Get()
        {
            var model = _simpleTypesService.GetKBSimpleTypeList();
            return Json(model);
        }

        public string Post(KBSimpleType entity) {
            _simpleTypesService.UpdateKBSimpleType(entity);
            return "OK";
        }

        public string Put(KBSimpleType entity)
        {
            _simpleTypesService.AddKBSimpleType(entity.Name, entity.Alias);
            return "OK";
        }

        public string Delete(int id)
        {
            _simpleTypesService.DeleteKBSimpleType(id);
            return "OK";
        }
    }
}