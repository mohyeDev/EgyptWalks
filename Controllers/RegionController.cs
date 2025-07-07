using EgyptWalks.Data;
using EgyptWalks.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly EgypWalksDbContext dbContext;

        public RegionController(EgypWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();

            return Ok(regions);

        }

        [HttpGet("{id:guid}")]
         public IActionResult GetById([FromRoute]Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if(region is null) return NotFound();

            return Ok(region);
            
        }

    }
}
