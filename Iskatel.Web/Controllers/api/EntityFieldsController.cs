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
    public class EntityFieldsController : ApiController
    {
        private IEntityFieldService _entityFieldsService;

        public EntityFieldsController(IEntityFieldService entityFieldsService)
        {
            _entityFieldsService = entityFieldsService;
        }

        public JsonResult<List<KBEntityField>> Get(int id)
        {
            var model = _entityFieldsService.GetKBEntityFieldList(id);
            return Json(model);
        }

        public string Post(KBEntityField entity) {
            _entityFieldsService.UpdateKBEntityField(entity);
            return "OK";
        }

        public string Put(int id, KBEntityField entity)
        {
            _entityFieldsService.AddKBEntityField(id, entity.Name, entity.Alias, entity.TypeId);
            return "OK";
        }

        public string Delete(int id)
        {
            _entityFieldsService.DeleteKBEntityField(id);
            return "OK";
        }
    }
}