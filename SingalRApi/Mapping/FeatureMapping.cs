using AutoMapper;
using SingalR.DtoLayer.FeatureDto;
using SingalR.EntityLayer.Entities;

namespace SingalRApi.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureDto>().ReverseMap();
        }
    }
}
