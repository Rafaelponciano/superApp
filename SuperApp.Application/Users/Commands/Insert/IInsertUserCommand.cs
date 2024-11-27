namespace SuperApp.Application.Users.Commands.Insert;

public interface IInsertUserCommand
{
    UserDTO Execute(InsertUserDTO insertUserDto);
}