using System.ComponentModel.DataAnnotations;

namespace Finances.Backend.Model
{
    public class GroupStatus
    {
        [Required]
        public byte IdGroupStatus { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
