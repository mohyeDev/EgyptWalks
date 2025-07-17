using AutoMapper;
using EgyptWalks.CustomActionFilter;
using EgyptWalks.Data;
using EgyptWalks.Mappings;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMapper mapper;

        public RegionController(EgypWalksDbContext dbContext, IRegionRepositiory regionRepositiory , IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepositiory = regionRepositiory;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepositiory.GetAllAsync();

            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);

        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles ="Reader")]

        public async Task<IActionResult>  GetById([FromRoute]Guid id)
        {
            var region = await regionRepositiory.GetByIdAsync(id);

            if(region is null) return NotFound();
            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
            
        }


        [HttpPost]
        [ValidateModelAtrribute]
        [Authorize(Roles ="Writer")]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegion )
        {
             

            var regionDomainModel = mapper.Map<Region>(addRegion);



            regionDomainModel = await regionRepositiory.CreateAsync(regionDomainModel);


            var regionDto = mapper.Map<RegionDto>(regionDomainModel);


            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }




        [HttpPut("{id:guid}")]
        [ValidateModelAtrribute]
        [Authorize(Roles = "Writer")]


        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {

            var RegionDomainModel = mapper.Map<Region>(updateRegion);
            RegionDomainModel = await regionRepositiory.UpdateAsync(id, RegionDomainModel);
            if (RegionDomainModel is null) return NotFound();
    

            mapper.Map<Region>(updateRegion);

          await dbContext.SaveChangesAsync();

            var regionDto = mapper.Map<RegionDto>(RegionDomainModel);
            return Ok(regionDto);


        }


        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Writer")]


        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepositiory.DeleteAsync(id);


            if (regionDomainModel is null) return NotFound();

      
            return Ok("Region Deleted Successfully!");
        }
    }
}
