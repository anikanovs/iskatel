using Iskatel.Model;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface ISimpleTypesService
    {
        void UpdateKBSimpleType(KBSimpleType entity);
        bool DeleteKBSimpleType(int id);
        List<KBSimpleType> GetKBSimpleTypeList();
        void AddKBSimpleType(string typeName, string typeAlias);
    }
}
