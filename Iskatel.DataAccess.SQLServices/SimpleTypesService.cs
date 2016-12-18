using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;
using System.Linq;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.DataAccess.SQLServices
{
    public class SimpleTypesService : ISimpleTypesService
    {
        public List<KBSimpleType> GetKBSimpleTypeList()
        {
            using (var c = new iskateli_devEntities1())
            {
                var query = from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.ParentId == (int)KBClassType.KBSimpleType
                            select new KBSimpleType()
                            {
                                Id = cl.Id,
                                Alias = cl.Alias,
                                Name = d.Data1
                            };
                return query.ToList();
            }
        }

        public void AddKBSimpleType(string typeName, string typeAlias)
        {
            using (var c = new iskateli_devEntities1())
            {
                var _class = c.Class.Create();
                _class.ParentId = (int)KBClassType.KBSimpleType;
                _class.TypeClassId = (int)KBClassType.KBSimpleType;
                _class.Alias = typeAlias;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = typeName;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public void UpdateKBSimpleType(KBSimpleType entity)
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

        public bool DeleteKBSimpleType(int id)
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
    }
}
