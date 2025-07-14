using AutoMapper;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;
using EgyptWalks.Repositiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyptWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepoistory walkRepoistory;

        public WalksController(IMapper mapper , IWalkRepoistory walkRepoistory)
        {
            this.mapper = mapper;
            this.walkRepoistory = walkRepoistory;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto) {


            // Map Dto To Domain Model 

            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepoistory.CreateAsync(walkDomainModel);

            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);




        }


        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepoistory.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));

        }


        [HttpGet("{id:guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepoistory.GetByIdAsync(id);
            if (walksDomainModel is null) return NotFound();

            
            return Ok(mapper.Map<WalkDto>(walksDomainModel));
        }


        [HttpPut("{id:guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateWalksRequestDto updateWalks)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalks);

            walkDomainModel =  await walkRepoistory.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel is null) return NotFound();

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }


        [HttpDelete("{id:guid}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var WalkDomainModel = await walkRepoistory.DeleteAsync(id);
            if (WalkDomainModel is null) return NotFound();

            return Ok();
        }

    }
}
