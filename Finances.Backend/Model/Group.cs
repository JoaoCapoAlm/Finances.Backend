using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Finances.Backend.Data.Enums;

namespace Finances.Backend.Model
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IdGroup { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome obrigatório!")]
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
        [DefaultValue(GroupStatusEnum.Active)]
        public byte IdStatus { get; set; }
        public virtual GroupStatus Status { get; set; }

    }
}
