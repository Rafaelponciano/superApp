using AutoMapper;
using SuperApp.Application.Heroes.Commands.Insert;
using SuperApp.Application.Heroes.Queries;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Infrastructure.Profiles;

public class SuperHeroProfile : Profile
{
    public SuperHeroProfile()
    {
        CreateMap<SuperHeroDTO, SuperHero>();
        CreateMap<SuperHero, SuperHeroDTO>();
        CreateMap<InsertHeroDTO, SuperHero>()
            .ForMember(dest => dest.Id, 
                act => act.Ignore());
    }
}