using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Heroes.Queries;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Application.Heroes.Commands.Insert;

public class InsertHeroCommand : IInsertHeroCommand
{
    private readonly IHeroService _heroService;
    private readonly IAutoMapperService _autoMapper;
    
    public InsertHeroCommand(IHeroService heroService, IAutoMapperService autoMapper)
    {
        _heroService = heroService;
        _autoMapper = autoMapper;
    }
    
    public SuperHeroDTO Execute(InsertHeroDTO insertHeroDto)
    {
        SuperHero superHero = _autoMapper.Map<InsertHeroDTO, SuperHero>(insertHeroDto);
            
        superHero = _heroService.Insert(superHero);

        SuperHeroDTO superHeroDto = _autoMapper.Map<SuperHero, SuperHeroDTO>(superHero);

        return superHeroDto;
    }
}