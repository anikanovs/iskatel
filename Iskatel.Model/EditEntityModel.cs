using System.Collections.Generic;

namespace Iskatel.Model
{
    public class EditEntityModel
    {
        public KBEntity Entity { get; set; }

        public AddKBEntityFieldModel AddFieldModel { get; set; }

        public List<KBSimpleType> Types { get; set; }
    }
}
