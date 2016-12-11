using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iskatel.Model;
using Iskatel.DataAccess.Intefaces;

namespace Iskatel.DataAccess.ArangoServices
{
    public class MainService : IMainService
    {
        public Source GetSource(int id)
        {
            return new Source()
            {
                Title = "Евгений Онегин",
                CreateDate = new Date(new DateTime(1825, 1, 1), false, false)
            };
        }
    }
}
