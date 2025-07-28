using EgyptWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Data
{
    public class EgypWalksDbContext : DbContext
    {
        public EgypWalksDbContext(DbContextOptions<EgypWalksDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Image> Images { get; set; }

        
    }
}
