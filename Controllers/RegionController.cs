using EgyptWalks.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>()
            {
                new Region
        {
            Id = Guid.NewGuid(),
            Name = "Alexandria",
            Code = "Alex",
            RegionImageUrl = "https://images.pexels.com/photos/1369212/pexels-photo-1369212.jpeg?auto=compress&cs=tinysrgb&w=800"
        },
        new Region
        {
            Id = Guid.NewGuid(),
            Name = "Cairo",
            Code = "Cai",
            RegionImageUrl = "https://images.pexels.com/photos/3584436/pexels-photo-3584436.jpeg?auto=compress&cs=tinysrgb&w=800"
        },
        new Region
        {
            Id = Guid.NewGuid(),
            Name = "Luxor",
            Code = "Lux",
            RegionImageUrl = "https://images.pexels.com/photos/1671010/pexels-photo-1671010.jpeg?auto=compress&cs=tinysrgb&w=800"
        },
        new Region
        {
            Id = Guid.NewGuid(),
            Name = "Aswan",
            Code = "Asw",
            RegionImageUrl = "https://images.pexels.com/photos/1666029/pexels-photo-1666029.jpeg?auto=compress&cs=tinysrgb&w=800"
        },
        new Region
        {
            Id = Guid.NewGuid(),
            Name = "Sharm El Sheikh",
            Code = "Sharm",
            RegionImageUrl = "https://images.pexels.com/photos/3680904/pexels-photo-3680904.jpeg?auto=compress&cs=tinysrgb&w=800"
        }
            };

            return Ok(regions);
        }

    }
}
