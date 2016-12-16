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
    }
}