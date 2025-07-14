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
            return await dbContext.Walks.ToListAsync();
        }
    }
}
