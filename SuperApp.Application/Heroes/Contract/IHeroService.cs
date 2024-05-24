using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Application.Heroes.Contract;

public interface IHeroService
{
    SuperHero Insert(SuperHero insertHero);
    SuperHero Update(SuperHero insertHero);
    void Delete(int id);
    List<SuperHero> GetAll();
    SuperHero GetById(int id);
}