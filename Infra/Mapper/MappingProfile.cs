using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace Infra.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PersonDto, Person>().ReverseMap();
        CreateMap<ProfilesDto, Profile>().ReverseMap();
        CreateMap<FlagDto, Flag>().ReverseMap();
        CreateMap<FeatureDto, Feature>().ReverseMap();
        CreateMap<EarlyBirdDto, EarlyBird>().ReverseMap();
        CreateMap<ChangesDto, Changes>().ReverseMap();
    }
}
