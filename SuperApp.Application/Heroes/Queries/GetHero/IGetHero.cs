namespace SuperApp.Application.Heroes.Queries;

public interface IGetHero
{
    Task<SuperHeroDTO> Execute(int id);
}