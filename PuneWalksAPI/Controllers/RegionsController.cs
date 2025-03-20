using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuneWalksAPI.CustomActionFilters;
using PuneWalksAPI.Data;
using PuneWalksAPI.Models.Domain;
using PuneWalksAPI.Models.DTO;
using PuneWalksAPI.Repositories;

namespace PuneWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly PuneWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(PuneWalksDbContext dbContext , IRegionRepository   regionRepository,IMapper mapper)
        {
            
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GET ALL REGIONS
        //GET:https://localhost:portnumber/api/regions

        [HttpGet]
      //  [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAll()
        {
            //GET data from database - domain Model
           // var regionsDomain = await dbContext.Regions.ToListAsync();
            var regionsDomain = await regionRepository.GetAllAsync();

            //Map Domain Models To DTOs
            //var regionsDto = new List<RegionDTO>();
            //foreach (var regionDomain in regionsDomain)
            //{
            //    regionsDto.Add(new RegionDTO()
            //    {
            //        Id = regionDomain.Id,
            //        Code = regionDomain.Code,
            //        Name = regionDomain.Name,
            //        RegionImageUrl = regionDomain.RegionImageUrl
            //    });
            //}

            //Map Domain Model to DTO
           //var regionsDto = mapper.Map<List<RegionDTO>>(regionsDomain);//mapper.Map<List<RegionDTO>(regionsDomain);
            //Return DTOs

            return Ok(mapper.Map<List<RegionDTO>>(regionsDomain));
            
        }
        //Get Single Region
        //GET:https://localhost:portnumber/api/regions/{id}
        [HttpGet("{id:guid}")]
       // [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            //GET region Domain model from database

           // var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetSingleAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            //var regionDto = new RegionDTO()
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

                
            //Return DTO back to client
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        //Post to create new Region
        //Post: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
       // [Authorize(Roles = "writer")]
        public async Task<IActionResult> Create ([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
           
            
                //Map or Convert Dto to Domain Model
                var regionDomain = mapper.Map<Region>(addRegionRequestDto);

                //use Domain Model to create Region
                regionDomain = await regionRepository.CreateAsync(regionDomain);

                //Map Domain Model back to DTO
                var regionDto = mapper.Map<RegionDTO>(regionDomain);
                return CreatedAtAction(nameof(GetSingle), new { id = regionDomain.Id }, regionDto);
            

            //Map or Convert Dto to Domain Model
            //var regionDomain = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
            //};

           // var regionDomain = mapper.Map<Region>(addRegionRequestDto);
            //Add Region Domain model to database
           // await dbContext.Regions.AddAsync(regionDomain);
            //await dbContext.SaveChangesAsync();

            //regionDomain = await regionRepository.CreateAsync(regionDomain);
            //Map Domain Model back to DTO

            //var regionDto = mapper.Map<RegionDTO>(regionDomain);
            //return CreatedAtAction(nameof(GetSingle),new { id = regionDomain.Id }, regionDto);
        }

        //Update Region
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
       // [Authorize(Roles = "writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionsRequestDTO updateRegionRequestDto)
        {
            
                //MapDTO to Domain Model
                var regionDomain = mapper.Map<Region>(updateRegionRequestDto);

                regionDomain = await regionRepository.UpdateAsync(id, regionDomain);
                if (regionDomain == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<RegionDTO>(regionDomain));
          
            //Map DTO to Domain Model
            //var regionDomain = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl

            //};

           // var regionDomain = mapper.Map<Region>(updateRegionRequestDto);
            //Update Region
           //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
          //regionDomain = await regionRepository.UpdateAsync(id, regionDomain);
          //  if (regionDomain == null)
          //  {
          //      return NotFound();
          //  }
            //Map AddRegionRequestDto to Region Domain Model
            //regionDomain.Code = updateRegionRequestDto.Code;
            //regionDomain.Name = updateRegionRequestDto.Name;
            //regionDomain.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            //await dbContext.SaveChangesAsync();

            //Convert Domain Model back to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            //var regionDto = mapper.Map<RegionDTO>(regionDomain);
           // return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        //Delete Region
        //DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
       // [Authorize(Roles = "writer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomain = await regionRepository.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //Delete Region
            // dbContext.Regions.Remove(regionDomain);
           //await dbContext.SaveChangesAsync();
            //Return deleted Region

              
            //map Domain Model back to DTO

            //var regionDto = new RegionDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

    }   
}
