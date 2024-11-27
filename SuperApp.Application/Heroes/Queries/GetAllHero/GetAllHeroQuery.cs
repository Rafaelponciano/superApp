using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Application.Heroes.Queries;

public class GetAllHeroQuery : IGetAllHeroQuery
{
    private readonly IHeroService _heroService;
    private readonly IAutoMapperService _autoMapper;
    
    public GetAllHeroQuery(IHeroService heroService, IAutoMapperService autoMapper)
    {
        _heroService = heroService;
        _autoMapper = autoMapper;
    }
    
    public Task<List<SuperHeroDTO>> Execute()
    {
        List<SuperHero> data = _heroService.GetAll();

        List<SuperHeroDTO> superHeroDTO = _autoMapper.MapList<SuperHero, SuperHeroDTO>(data);
        
        return Task.FromResult(superHeroDTO);
    }
}