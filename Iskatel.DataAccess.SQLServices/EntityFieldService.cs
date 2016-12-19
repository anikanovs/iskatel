using Iskatel.DataAccess.Intefaces;
using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;
using System.Linq;

namespace Iskatel.DataAccess.SQLServices
{
    public class EntityFieldService : IEntityFieldService
    {
        public void AddKBEntityField(int entityId, string name, string alias, int typeId)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.Create();
                _class.ParentId = entityId;
                _class.TypeClassId = typeId;
                _class.Alias = alias;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = name;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public void DeleteKBEntityField(int id)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.SingleOrDefault(x => x.Id == id);
                c.Class.Remove(_class);
                c.SaveChanges();
            }
        }

        public List<KBEntityField> GetKBEntityFieldList(int entityId)
        {
            using (var c = new iskateli_devEntities1())
            {
                return (from cl in c.Class
                        join d in c.Data on cl.Id equals d.ClassId
                        join td in c.Data on cl.TypeClassId equals td.ClassId
                        where cl.ParentId == entityId && d.EntityId == null && d.RelationId == null
                        select new KBEntityField()
                        {
                            Id = cl.Id,
                            Alias = cl.Alias,
                            Name = d.Data1,
                            TypeId = cl.TypeClassId.Value,
                            TypeName = td.Data1
                        }).ToList();
            }
        }

        public void UpdateKBEntityField(KBEntityField entity)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.SingleOrDefault(x => x.Id == entity.Id);
                _class.Alias = entity.Alias;
                _class.TypeClassId = entity.TypeId;
                var data = c.Data.SingleOrDefault(x => x.ClassId == entity.Id);
                data.Data1 = entity.Name;
                c.SaveChanges();
            }
        }
    }
}
