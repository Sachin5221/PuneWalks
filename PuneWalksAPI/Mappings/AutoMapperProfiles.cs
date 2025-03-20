using AutoMapper;
using PuneWalksAPI.Models.Domain;
using PuneWalksAPI.Models.DTO;

namespace PuneWalksAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap(); //ReverseMap() is used to map from RegionDTO to Region>

            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionsRequestDTO, Region>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap(); //ReverseMap() is used to map from Walk to AddWalkRequestDTO
            CreateMap<Walk, WalkDTO>().ReverseMap();//ReverseMap() is used to map from Walk to AddWalkRequestDTO
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap(); //ReverseMap() is used to map from Walk to AddWalkRequestDTO>
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();
        }

    }
}
