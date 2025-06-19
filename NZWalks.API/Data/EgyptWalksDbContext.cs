using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class EgyptWalksDbContext : DbContext
    {
        public EgyptWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Region> regions { get; set; }

        public DbSet<Diffuculty> diffuculties { get; set; } 


        public DbSet<Walk> walks { get; set; }  

    }
}
