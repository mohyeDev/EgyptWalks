using EgyptWalks.Data;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly EgypWalksDbContext dbContext;
        private readonly IRegionRepositiory regionRepositiory;

        public RegionController(EgypWalksDbContext dbContext, IRegionRepositiory regionRepositiory)
        {
            this.dbContext = dbContext;
            this.regionRepositiory = regionRepositiory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepositiory.GetAllAsync();


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
         public async Task<IActionResult>  GetById([FromRoute]Guid id)
        {
            var region = await regionRepositiory.GetByIdAsync(id);

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


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegion )
        {

            var regionDomainModel = new Region()
            {
                Code = addRegion.Code,
                RegionImageUrl = addRegion.RegionImageUrl,
                Name = addRegion.Name,
            };

            regionDomainModel = await regionRepositiory.CreateAsync(regionDomainModel);


            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };


            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }



        [HttpPut("{id:guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {

            var RegionDomainModel = new Region()
            {
                Code = updateRegion.Code,
                RegionImageUrl = updateRegion.RegionImageUrl,
                Name = updateRegion.Name,

            };
            RegionDomainModel = await regionRepositiory.UpdateAsync(id, RegionDomainModel);
            if (RegionDomainModel is null) return NotFound();
            RegionDomainModel.Name = updateRegion.Name;
            RegionDomainModel.Code = updateRegion.Code;
            RegionDomainModel.RegionImageUrl = updateRegion.RegionImageUrl;

          await  dbContext.SaveChangesAsync();

            var regionDto = new RegionDto()
            {
                Id = RegionDomainModel.Id,
                Code = RegionDomainModel.Code,
                RegionImageUrl = RegionDomainModel.RegionImageUrl,
                Name = RegionDomainModel.Name
            };
            return Ok(regionDto);


        }


        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepositiory.DeleteAsync(id);


            if (regionDomainModel is null) return NotFound();

      
            return Ok("Region Deleted Successfully!");
        }
    }
}
