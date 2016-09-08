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
                Authors = new List<Person>()
                {
                    new Person("Александр", "Сергеевич", "Пушкин",
                    new Date(new DateTime(1799, 6, 6)), "г. Москва", new Date(new DateTime(1837, 2, 10)))
                },
                Characters = new List<Human>()
                {
                    new Human() { FirstName = "Татьяна", LastName = "Ларина" },
                    new Human() { FirstName = "Евгений", LastName = "Онегин" }
                },
                CreateDate = new Date(new DateTime(1825, 1, 1), false, false),
                Genres = new List<string>()
                {

                }
            };
        }
    }
}
