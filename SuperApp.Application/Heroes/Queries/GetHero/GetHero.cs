using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Application.Heroes.Queries;

public class GetHero : IGetHero
{
    private readonly IHeroService _heroService;
    private readonly IAutoMapperService _autoMapper;
    
    public GetHero(IHeroService heroService, IAutoMapperService autoMapper)
    {
        _heroService = heroService;
        _autoMapper = autoMapper;
    }
    
    public Task<SuperHeroDTO> Execute(int id)
    {
        SuperHero superHero = _heroService.GetById(id);

        SuperHeroDTO superHeroDto = _autoMapper.Map<SuperHero, SuperHeroDTO>(superHero);

        return Task.FromResult(superHeroDto);
    }
}