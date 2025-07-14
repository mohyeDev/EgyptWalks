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

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk is null) return null; 

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;

        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Diffuclty").Include("Region").ToListAsync();
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include(x => x.Diffuclty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk is null) return null;


            existingWalk.Name = walk.Name;
            existingWalk.DiffucltyId = walk.DiffucltyId;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.RegionId = walk.RegionId;


            await dbContext.SaveChangesAsync();

            return await dbContext.Walks
              .Include(w => w.Region)
              .Include(w => w.Diffuclty)
              .FirstOrDefaultAsync(w => w.Id == id);


        }
    }
}
