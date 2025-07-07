using EgyptWalks.Data;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;
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


            var regionDto = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            return Ok(regionDto);

        }

        [HttpGet("{id:guid}")]
         public IActionResult GetById([FromRoute]Guid id)
        {
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(region is null) return NotFound();
            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl,
            };

            return Ok(regionDto);
            
        }

    }
}
