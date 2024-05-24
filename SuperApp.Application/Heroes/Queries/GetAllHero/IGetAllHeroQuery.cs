namespace SuperApp.Application.Heroes.Queries;

public interface IGetAllHeroQuery
{
    Task<List<SuperHeroDTO>> Execute();
}
