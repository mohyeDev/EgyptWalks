using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Data
{
    public class EgyptWalksAuthDbContext : IdentityDbContext
    {


        public EgyptWalksAuthDbContext(DbContextOptions<EgyptWalksAuthDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "76F5E9A9-AF9E-44E5-BD72-E73DC847DE7C",
                    ConcurrencyStamp = "76F5E9A9-AF9E-44E5-BD72-E73DC847DE7C",
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()

                },

                 new IdentityRole
                {
                    Id = "DB6A88EA-A610-4E36-AC44-005C0161C7B4",
                    ConcurrencyStamp = "DB6A88EA-A610-4E36-AC44-005C0161C7B4",
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);  
        }
    }
}
