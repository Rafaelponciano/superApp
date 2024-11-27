using SuperApp.Domain.SuperHeroes;
using SuperApp.Repository.Data;

namespace SuperApp.Repository.Repositories.HeroRepository;

public class HeroRepository : IHeroRepository
{
    private readonly DataContext _context;

    public HeroRepository(DataContext context)
    {
        _context = context;
    }

    public SuperHero Insert(SuperHero insertHero)
    {
        _context.SuperHeroes.Add(insertHero);
        _context.SaveChanges();

        return insertHero;
    }

    public SuperHero Update(SuperHero hero)
    {
        var updateHero = _context.SuperHeroes.Find(hero.Id);

        if (updateHero is null) throw new Exception("NotFound");

        updateHero.Name = hero.Name;
        updateHero.FirstName = hero.FirstName;
        updateHero.LastName = hero.LastName;
        updateHero.Place = hero.Place;
        updateHero.Power = hero.Power;
        updateHero.IsActive = hero.IsActive;
        
        _context.SuperHeroes.Update(updateHero);
        _context.SaveChanges();

        return updateHero;
    }

    public void Delete(int id)
    {
        var dbHero = _context.SuperHeroes.Find(id);

        if (dbHero is null) throw new Exception("NotFound");
        
        _context.SuperHeroes.Remove(dbHero);
        _context.SaveChanges();
    }

    public List<SuperHero> GetAll()
    {
        List<SuperHero> superHero = _context.SuperHeroes.ToList();
    
        return superHero;
    }

    public SuperHero GetById(int id)
    {
        SuperHero superHero = _context.SuperHeroes.Find(id) ?? throw new Exception("NotFound");

        return superHero;
    }
}