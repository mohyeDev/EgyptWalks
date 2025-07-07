using EgyptWalks.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Repositiory
{
    public interface IRegionRepositiory
    {

         public Task<List<Region>> GetAllAsync();


    }
}
