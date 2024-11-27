namespace SuperApp.Application.Users.Commands.Delete;

public interface IDeleteUserCommand
{
    void Execute(int id);
}