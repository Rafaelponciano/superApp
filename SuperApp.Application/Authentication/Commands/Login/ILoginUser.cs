namespace SuperApp.Application.Authentication.Commands.Login;

public interface ILoginUser
{
    AuthenticationResultDTO Execute(LoginUserDTO loginUserDto);
}