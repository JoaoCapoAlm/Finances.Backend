using Finances.Backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finances.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) {
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<GroupStatus> GroupStatus { get; set; }
    }
}
