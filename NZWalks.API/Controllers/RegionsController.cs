using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

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
            return Ok(regions);
        }


        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetById([FromRoute]Guid id)
        {
            var regions = _context.regions.Find(id);

            if(regions is null)
            {
                return NotFound();
            }

            return Ok(regions);

        }

    }


    
}
