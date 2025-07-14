using EgyptWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Data
{
    public class EgypWalksDbContext : DbContext
    {
        public EgypWalksDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Region> Regions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Diffuclty>
            {
                new Diffuclty
                {
                    Id = Guid.NewGuid(),
                    Name = "Easy"
                },

                new Diffuclty
                {
                    Id = Guid.NewGuid(),
                    Name = "Medium",

                },
                new Diffuclty
                {
                    Id = Guid.NewGuid(),
                    Name =  "Hard"
                }
            };


            modelBuilder.Entity<Diffuclty>().HasData(difficulties);
        }

    }
}
