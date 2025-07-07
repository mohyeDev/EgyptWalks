using EgyptWalks.Data;
using EgyptWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Repositiory
{
    public class SQLRegionRepositiory : IRegionRepositiory
    {
        private readonly EgypWalksDbContext dbContext;

        public SQLRegionRepositiory(EgypWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
