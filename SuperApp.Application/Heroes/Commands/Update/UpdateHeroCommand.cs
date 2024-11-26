using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Heroes.Queries;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Application.Heroes.Commands.Update;

public class UpdateHeroCommand : IUpdateHeroCommand
{
    private readonly IHeroService _heroService;
    private readonly IAutoMapperService _autoMapperService;
    
    public UpdateHeroCommand(IHeroService heroService, IAutoMapperService autoMapperService)
    {
        _heroService = heroService;
        _autoMapperService = autoMapperService;
    }
    public SuperHeroDTO Execute(SuperHeroDTO updateSuperHeroDto)
    {
        SuperHero superHero = _autoMapperService.Map<SuperHeroDTO, SuperHero>(updateSuperHeroDto);

        superHero = _heroService.Update(superHero);

        return _autoMapperService.Map<SuperHero, SuperHeroDTO>(superHero);
    }
}