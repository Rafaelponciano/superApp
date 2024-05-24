using SuperApp.Application.Heroes.Commands.Delete;
using SuperApp.Application.Heroes.Contract;

namespace SuperApp.Application.Heroes.Commands;

public class DeleteHeroCommand : IDeleteHeroCommand
{
    private readonly IHeroService _heroService;

    public DeleteHeroCommand(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public void Execute(int id)
    {
        _heroService.Delete(id);
    }
}