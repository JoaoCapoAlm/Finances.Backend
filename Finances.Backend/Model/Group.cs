using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Finances.Backend.Data.Enums;

namespace Finances.Backend.Model
{
    public class Group
    {
        public Guid IdGroup { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome obrigatório!")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        [DefaultValue(GroupStatusEnum.Active)]
        public GroupStatus IdStatus { get; set; }
    }
}
