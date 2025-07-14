using AutoMapper;
using EgyptWalks.Models.Domain;
using EgyptWalks.Models.DTo;

namespace EgyptWalks.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<WalkDto, Walk>().ReverseMap();


        }
    }
}
