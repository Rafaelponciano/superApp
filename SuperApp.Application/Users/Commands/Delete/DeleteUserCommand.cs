using SuperApp.Application.Users.Contract;

namespace SuperApp.Application.Users.Commands.Delete;

public class DeleteUserCommand: IDeleteUserCommand
{
    private readonly IUserService _userService;

    public DeleteUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(int id)
    {
        _userService.Delete(id);
    }
}