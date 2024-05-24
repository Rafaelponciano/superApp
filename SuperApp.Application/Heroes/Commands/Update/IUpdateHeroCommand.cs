using SuperApp.Application.Heroes.Queries;

namespace SuperApp.Application.Heroes.Commands.Update;

public interface IUpdateHeroCommand
{
    SuperHeroDTO Execute(SuperHeroDTO updateSuperHeroDto);
}