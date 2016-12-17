using Iskatel.Model;
using Iskatel.Model.ORM;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface IClassService
    {
        KBClass Get(int id, iskateli_devEntities1 context = null);

        List<KBSimpleType> GetKBSimpleTypeList();

        void AddKBSimpleType(string typeName, string typeAlias);

        List<IdNamePair> GetKBEntityList();

        void AddKBEntity(string entityName, string entityAlias);

        void AddFieldToKBEntity(int entityId, string alias, string fieldName, int typeId);

        KBEntity GetKBEntity(int id);

        void UpdateKBSimpleType(KBSimpleType entity);

        bool DeleteKBSimpleType(int id);
    }
}
