using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;
using System.Linq;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.DataAccess.SQLServices
{
    public class EntityService : IEntityService
    {
        public List<KBEntity> GetKBEntityList()
        {
            using (var c = new iskateli_devEntities1())
            {
                var query = from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.ParentId == (int)KBClassType.KBEntity
                            select new KBEntity()
                            {
                                Id = cl.Id,
                                Name = d.Data1,
                                Alias = cl.Alias
                            };
                return query.ToList();
            }
        }

        public KBEntity GetKBEntity(int id)
        {
            using (var c = new iskateli_devEntities1())
            {
                var query = from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.Id == id
                            select new KBEntity()
                            {
                                Id = cl.Id,
                                Name = d.Data1,
                                Alias = cl.Alias
                            };
                return query.SingleOrDefault();
            }
        }

        public void AddKBEntity(string entityName, string entityAlias)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.Create();
                _class.ParentId = (int)KBClassType.KBEntity;
                _class.TypeClassId = (int)KBClassType.KBEntity;
                _class.Alias = entityAlias;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = entityName;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public bool DeleteKBEntity(int id)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.SingleOrDefault(x => x.Id == id);
                var entities = c.Entity.Where(x => x.ClassId == id);
                if (entities.Any()) return false;
                c.Class.Remove(_class);
                c.SaveChanges();
                return true;
            }
        }

        public void UpdateKBEntity(KBEntity entity)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.SingleOrDefault(x => x.Id == entity.Id);
                _class.Alias = entity.Alias;
                var data = c.Data.SingleOrDefault(x => x.ClassId == entity.Id);
                data.Data1 = entity.Name;
                c.SaveChanges();
            }
        }
    }
}
