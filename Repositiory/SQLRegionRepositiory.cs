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

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existingRegion is null) return null;

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;  
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
             return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion is null) return null;

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl  = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return existingRegion;

        }
    }
}
