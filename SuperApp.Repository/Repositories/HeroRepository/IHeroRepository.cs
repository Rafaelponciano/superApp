using SuperApp.Domain.SuperHeroes;

namespace SuperApp.Repository.Repositories.HeroRepository;

public interface IHeroRepository
{
    SuperHero Insert(SuperHero insertHero);
    SuperHero Update(SuperHero insertHero);
    void Delete(int id);
    List<SuperHero> GetAll();
    SuperHero GetById(int id);
}