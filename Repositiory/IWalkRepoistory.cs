using EgyptWalks.Models.Domain;

namespace EgyptWalks.Repositiory
{
    public interface IWalkRepoistory
    {

        public Task<Walk> CreateAsync(Walk walk);

        public Task<List<Walk>> GetAllAsync(string? filterOn = null , string? filterQuery = null , string? sortBy = null , bool isAscending = true,int pageSize = 5 , int pageNumber = 1);

        public Task<Walk?> GetByIdAsync(Guid id);

        public Task<Walk?> UpdateAsync(Guid id, Walk walk);

        public Task<Walk?> DeleteAsync(Guid id);

    }
}
