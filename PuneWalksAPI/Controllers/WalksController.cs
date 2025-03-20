using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuneWalksAPI.CustomActionFilters;
using PuneWalksAPI.Models.Domain;
using PuneWalksAPI.Models.DTO;
using PuneWalksAPI.Repositories;

namespace PuneWalksAPI.Controllers
{
    //api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper; //We use this.mapper to differentiate between the class-level field(mapper) and the constructor parameter(mapper).
            this.walkRepository = walkRepository;
        }


        //Create Walks
        //POST:https://localhost:portnumber/api/walks
        [HttpPost]//Attribute
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDto)
        {
           
                //Map DTO to Domain model
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await walkRepository.CreateAsync(walkDomainModel);

                //Map Domain model to DTO
                return Ok(mapper.Map<WalkDTO>(walkDomainModel)); 

            //Map DTO to Domain model
            //var walkDomain = new Walk
            //{
            //    Length = addWalkRequestDto.Length,
            //    Name = addWalkRequestDto.Name,
            //    RegionId = addWalkRequestDto.RegionId,
            //    WalkDifficultyId = addWalkRequestDto.WalkDifficultyId
            //};


            //var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            //if (walkDomainModel != null)
            //{
            //    await walkRepository.CreateAsync(walkDomainModel);
            //    //Map Domain model to DTO
            //    return Ok(mapper.Map<WalkDTO>(walkDomainModel));
            //}
            //else
            //{
            //    return BadRequest("Failed to map AddWalkRequestDTO to Walk");
            //}

            // await walkRepository.CreateAsync(walkDomainModel);
            //Map Domain model to DTO
            // return Ok(mapper.Map<WalkDTO>(walkDomainModel) );

            //Get Walks
            //GET:https://localhost:portnumber/api/walks

          



        }
        //Get Walks
        //GET:https://localhost:portnumber/api/walks?filterOn=Name&filterQuery=Track?sortBy=Name&isAsccending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery
            ,[FromQuery]string? sortBy, [FromQuery]bool? isAsccending,
             [FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 1000)
        {
            var walksDomain = await walkRepository.GetAllAsync(filterOn, filterQuery,sortBy, isAsccending ?? true,
                                                               pageNumber,pageSize);
           //Map Domain model to DTO
            return Ok(mapper.Map<List<WalkDTO>>(walksDomain));
        }

        //Get Walk By Id
        //GET:https://localhost:portnumber/api/walks/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var walkDomain = await walkRepository.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();  
            }
            //Map Domain model to DTO
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }

        //Update Walk
        //PUT:https://localhost:portnumber/api/walks/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDTO updateWalkRequestDTO)
        {
           
                var walkDomain = mapper.Map<Walk>(updateWalkRequestDTO);

                walkDomain = await walkRepository.UpdateAsync(id, walkDomain);
                if (walkDomain == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<WalkDTO>(walkDomain));

          
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomain));
        }
    }
        

}
