using EgyptWalks.Models.Domain;

namespace EgyptWalks.Repositiory
{
    public interface IWalkRepoistory
    {

        public Task<Walk> CreateAsync(Walk walk);

    }
}
