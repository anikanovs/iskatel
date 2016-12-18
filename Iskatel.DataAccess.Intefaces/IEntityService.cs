using Iskatel.Model;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface IEntityService
    {
        void UpdateKBEntity(KBEntity entity);
        bool DeleteKBEntity(int id);
        List<KBEntity> GetKBEntityList();
        void AddKBEntity(string typeName, string typeAlias);
    }
}
