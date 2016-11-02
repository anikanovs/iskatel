using System.ComponentModel.DataAnnotations;

namespace Iskatel.Web.Models
{
    public class AddKBEntityFieldModel
    {
        public int KBEntityId { get; set; }
        [Display(Name="Alias")]
        public string Alias { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Тип")]
        public int TypeId { get; set; }
    }
}
