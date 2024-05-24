using SuperApp.Application.Heroes.Contract;
using SuperApp.Domain.SuperHeroes;
using SuperApp.Repository.Repositories.HeroRepository;

namespace SuperApp.Infrastructure.Services;

public class HeroService : IHeroService
{
    private readonly IHeroRepository _heroRepository;
    
    public HeroService(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public SuperHero Insert(SuperHero insertHero)
    {
        return _heroRepository.Insert(insertHero);
    }

    public SuperHero Update(SuperHero hero)
    {
        return _heroRepository.Update(hero);
    }

    public void Delete(int id)
    {
        _heroRepository.Delete(id);
    }

    public List<SuperHero> GetAll()
    {
        return _heroRepository.GetAll();;
    }

    public SuperHero GetById(int id)
    {
        SuperHero superHero = _heroRepository.GetById(id) ?? throw new Exception("NotFound");

        return superHero;
    }
}