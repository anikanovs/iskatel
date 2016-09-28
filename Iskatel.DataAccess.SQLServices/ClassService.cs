using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iskatel.Model;

namespace Iskatel.DataAccess.SQLServices
{
    public class ClassService
    {
        public Class Get(int id, ORM.iskateli_devEntities context = null)
        {
            using (var c = context == null ? new ORM.iskateli_devEntities() : context)
            {
                // выбор класса из БД
                var source = c.Class.SingleOrDefault(x => x.Id == id);
                if (source == null) return null;
                // конструирование класса
                var root = new Class(source.Id);
                if (source.TypeClassId.HasValue)
                    root.Type = Get(source.TypeClassId.Value, c); // получить тип из БД
                // заполнить поля класса
                GetChildren(root, c);
                return root;
            }
        }

        private void GetChildren(Class parent, ORM.iskateli_devEntities context)
        {
            // выбор списка классов из БД
            var childSources = context.Class.Where(x => x.ParentId == parent.Id);
            foreach (var childSource in childSources)
            {
                // конструирование класса
                var child = new Class(childSource.Id);
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
    }
}
