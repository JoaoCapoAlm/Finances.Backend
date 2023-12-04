using System.ComponentModel.DataAnnotations;

namespace Finances.Backend.Model
{
    public class GroupStatus
    {
        [Key]
        public byte IdGroupStatus { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
