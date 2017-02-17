using Iskatel.Model;
using System.Collections.Generic;

namespace Iskatel.DataAccess.Intefaces
{
    public interface IPersonService
    {
        List<EntityHeader> GetList();

        void Delete(int id);
    }
}
