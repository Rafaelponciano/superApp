namespace SuperApp.Application.Users.Commands.Update;

public interface IUpdateUserCommand
{
    UserDTO Execute(UpdateUserDTO updateUserDto);
}