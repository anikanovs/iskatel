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
    public class PersonController : ApiController
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        public JsonResult<List<EntityHeader>> Get()
        {
            var model = _personService.GetList();
            return Json(model);
        }

        //public string Post(KBSimpleType entity) {
        //    _simpleTypesService.UpdateKBSimpleType(entity);
        //    return "OK";
        //}

        //public string Put(KBSimpleType entity)
        //{
        //    _simpleTypesService.AddKBSimpleType(entity.Name, entity.Alias);
        //    return "OK";
        //}

        public string Delete(int id)
        {
            _personService.Delete(id);
            return "OK";
        }
    }
}