using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface IClassService
    {
        KBClass Get(int id, iskateli_devEntities context = null);

        List<KBSimpleType> GetKBSimpleTypeList();

        void AddKBSimpleType(string typeName);

        List<IdNamePair> GetKBEntityList();

        void AddKBEntity(string entityName);

        void AddFieldToKBEntity(int entityId, string fieldName, int typeId);

        KBEntity GetKBEntity(int id);
    }
}
