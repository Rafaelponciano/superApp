namespace SuperApp.Application.Heroes.Commands.Delete;

public interface IDeleteHeroCommand
{
    void Execute(int id);
}