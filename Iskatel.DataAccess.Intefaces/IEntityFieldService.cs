using Iskatel.Model;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface IEntityFieldService
    {
        List<KBEntityField> GetKBEntityFieldList(int entityId);
        void AddKBEntityField(int entityId, string name, string alias, int typeId);
        void UpdateKBEntityField(KBEntityField entity);
        void DeleteKBEntityField(int id);
    }
}
