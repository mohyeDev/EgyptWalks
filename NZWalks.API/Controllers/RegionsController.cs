using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly EgyptWalksDbContext _context;

        public RegionsController(EgyptWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _context.regions.ToList();

            var regionsDto = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }


            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _context.regions.Find(id);

            if (region is null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);

        }


        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl

            };

            _context.regions.Add(regionDomainModel);
            _context.SaveChanges();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);

        }


        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
           var regionsDomainModel = _context.regions.Find(id);

            if(regionsDomainModel is null)
            {
                return NotFound();
            }

            regionsDomainModel.Code = updateRegionRequestDto.Code;
            regionsDomainModel.Name = updateRegionRequestDto.Name;
            regionsDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            _context.SaveChanges();

            var regionDto = new RegionDto()
            {
                Id = regionsDomainModel.Id,
                Name = regionsDomainModel.Name,
                Code = regionsDomainModel.Code,
                RegionImageUrl = regionsDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult Delete([FromRoute]Guid id)
        {
            var regionDomainModel = _context.regions.Find(id);
            if (regionDomainModel is null) { 
                
                return NotFound();
            }

            _context.regions.Remove(regionDomainModel);
            _context.SaveChanges();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }



        
    }


    
}
