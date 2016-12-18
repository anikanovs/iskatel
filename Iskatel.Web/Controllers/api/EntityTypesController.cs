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
    public class EntityTypesController : ApiController
    {
        private IEntityService _entityTypesService;

        public EntityTypesController(IEntityService entityTypesService)
        {
            _entityTypesService = entityTypesService;
        }

        public JsonResult<List<KBEntity>> Get()
        {
            var model = _entityTypesService.GetKBEntityList();
            return Json(model);
        }

        public string Post(KBEntity entity) {
            _entityTypesService.UpdateKBEntity(entity);
            return "OK";
        }

        public string Put(KBEntity entity)
        {
            _entityTypesService.AddKBEntity(entity.Name, entity.Alias);
            return "OK";
        }

        public string Delete(int id)
        {
            _entityTypesService.DeleteKBEntity(id);
            return "OK";
        }
    }
}