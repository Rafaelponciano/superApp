using SuperApp.Application.Heroes.Queries;

namespace SuperApp.Application.Heroes.Commands.Insert;

public interface IInsertHeroCommand
{
    SuperHeroDTO Execute(InsertHeroDTO insertHeroDto);
}