using Finances.Backend.Data.Enums;
using Finances.Backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finances.Backend.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts) {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var groupStatusEnum = Enum.GetValues(typeof(GroupStatusEnum));
            List<GroupStatus> groupStatus = new List<GroupStatus>();

            foreach(var gs in groupStatusEnum)
            {
                groupStatus.Append(new GroupStatus()
                {
                    IdGroupStatus = (byte)gs.GetHashCode(),
                    Name = gs.ToString()
                });
            }

            builder.Entity<GroupStatus>().HasData(groupStatus);
            base.OnModelCreating(builder);
        }
    }
}
