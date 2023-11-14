using Microsoft.AspNetCore.Identity;

namespace Finances.Backend.Model
{
    public class User : IdentityUser
    {
        public DateTime Birth { get; set; }
        public User() : base() { }
    }
}
