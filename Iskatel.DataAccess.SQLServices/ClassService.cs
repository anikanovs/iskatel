using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;
using System.Linq;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.DataAccess.SQLServices
{
    public class ClassService : IClassService
    {
        public KBClass Get(int id, iskateli_devEntities context = null)
        {
            using (var c = context == null ? new iskateli_devEntities() : context)
            {
                // выбор класса из БД
                var source = c.Class.SingleOrDefault(x => x.Id == id);
                if (source == null) return null;
                // конструирование класса
                var root = new KBClass(source.Id);
                if (source.TypeClassId.HasValue)
                    root.Type = Get(source.TypeClassId.Value, c); // получить тип из БД
                // заполнить поля класса
                GetChildren(root, c);
                return root;
            }
        }

        private void GetChildren(KBClass parent, iskateli_devEntities context)
        {
            // выбор списка классов из БД
            var childSources = context.Class.Where(x => x.ParentId == parent.Id);
            foreach (var childSource in childSources)
            {
                // конструирование класса
                var child = new KBClass(childSource.Id);
                if (childSource.TypeClassId.HasValue)
                    child.Type = Get(childSource.TypeClassId.Value, context); // получить тип из БД
                // заполнить дочерние поля дочернего класса
                GetChildren(child, context);
                // установка ссылки "Родитель"
                child.Parent = parent;
                // добавление в коллекцию полей родителя
                parent.Fields.Add(child);
            }
        }

        public List<KBSimpleType> GetKBSimpleTypeList()
        {
            using (var c = new iskateli_devEntities())
            {
                var query = from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.ParentId == (int)KBClassType.KBSimpleType
                            select new KBSimpleType()
                            {
                                Id = cl.Id,
                                Name = d.Data1
                            };
                return query.ToList(); 
            }
        }

        public void AddKBSimpleType(string typeName)
        {
            using (var c = new iskateli_devEntities())
            {
                var _class = c.Class.Create();
                _class.ParentId = (int)KBClassType.KBSimpleType;
                _class.TypeClassId = (int)KBClassType.KBSimpleType;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = typeName;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public List<IdNamePair> GetKBEntityList()
        {
            using (var c = new iskateli_devEntities())
            {
                var query = from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.ParentId == (int)KBClassType.KBEntity
                            select new IdNamePair()
                            {
                                Id = cl.Id,
                                Name = d.Data1
                            };
                return query.ToList();
            }
        }

        public void AddKBEntity(string entityName)
        {
            using (var c = new iskateli_devEntities())
            {
                var _class = c.Class.Create();
                _class.ParentId = (int)KBClassType.KBEntity;
                _class.TypeClassId = (int)KBClassType.KBEntity;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = entityName;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public void AddFieldToKBEntity(int entityId, string fieldName, int typeId)
        {
            using (var c = new iskateli_devEntities())
            {
                var _class = c.Class.Create();
                _class.ParentId = entityId;
                _class.TypeClassId = typeId;
                c.Class.Add(_class);
                c.SaveChanges();
                var data = c.Data.Create();
                data.ClassId = _class.Id;
                data.Data1 = fieldName;
                c.Data.Add(data);
                c.SaveChanges();
            }
        }

        public KBEntity GetKBEntity(int id)
        {
            using (var c = new iskateli_devEntities())
            {
                var query = (from cl in c.Class
                            join d in c.Data on cl.Id equals d.ClassId
                            where cl.Id == id
                            select new
                            {
                                Id = cl.Id,
                                Name = d.Data1
                            }).SingleOrDefault();
                var result = new KBEntity()
                {
                    Id = query.Id,
                    Name = query.Name
                };
                var fields = (from cl in c.Class
                              join d in c.Data on cl.Id equals d.ClassId
                              join td in c.Data on cl.TypeClassId equals td.ClassId
                              where cl.ParentId == id && d.EntityId == null && d.RelationId == null
                              select new KBEntityField()
                              {
                                  Id = cl.Id,
                                  Name = d.Data1,
                                  TypeId = cl.TypeClassId.Value,
                                  TypeName = td.Data1
                              }).ToList();
                result.Fields = fields;
                return result;
            }
        }
    }
}
