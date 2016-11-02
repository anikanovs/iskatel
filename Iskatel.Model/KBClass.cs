using System.Collections.Generic;

namespace Iskatel.Model
{
    public class KBClass
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public KBClass Type { get; set; }
        public KBClass Parent { get; set; }
        public List<KBClass> Fields { get; set; }

        public KBClass(int id)
        {
            Id = id;
        }
    }
}
