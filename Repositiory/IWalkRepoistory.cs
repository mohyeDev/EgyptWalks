using EgyptWalks.Models.Domain;

namespace EgyptWalks.Repositiory
{
    public interface IWalkRepoistory
    {

        public Task<Walk> CreateAsync(Walk walk);

        public Task<List<Walk>> GetAllAsync();

        public Task<Walk> GetByIdAsync(Guid id);

    }
}
