using EgyptWalks.Data;
using EgyptWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Repositiory
{
    public class SQLWalkRepository : IWalkRepoistory
    {
        private readonly EgypWalksDbContext dbContext;

        public SQLWalkRepository(EgypWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Diffuclty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
           return await dbContext.Walks.Include(x => x.Diffuclty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
