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


        [HttpPost]

        public IActionResult Create([FromBody] AddRegionRequestDto addRegion )
        {

            var regionDomainModel = new Region()
            {
                Code = addRegion.Code,
                RegionImageUrl = addRegion.RegionImageUrl,
                Name = addRegion.Name,
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

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

        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {

            var RegionDomainModel = dbContext.Regions.Find(id);

            if (RegionDomainModel is null) return NotFound();

            RegionDomainModel.Name = updateRegion.Name;
            RegionDomainModel.Code = updateRegion.Code;
            RegionDomainModel.RegionImageUrl = updateRegion.RegionImageUrl;

            dbContext.SaveChanges();

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

        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel is null) return NotFound();

            dbContext.Regions.Remove(regionDomainModel);

            dbContext.SaveChanges();

            return Ok("Region Deleted Successfully!");
        }
    }
}
