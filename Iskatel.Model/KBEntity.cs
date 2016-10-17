using System.Collections.Generic;

namespace Iskatel.Model
{
    public class KBEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<KBEntityField> Fields { get; set; }
    }
}
