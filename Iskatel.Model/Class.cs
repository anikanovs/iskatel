using System.Collections.Generic;

namespace Iskatel.Model
{
    public class Class
    {
        public int Id { get; set; }
        public Class Type { get; set; }
        public Class Parent { get; set; }
        public List<Class> Fields { get; set; }

        public Class(int id)
        {
            Id = id;
        }
    }
}
