namespace SuperApp.Application.Authentication.Commands.Register;

public interface IRegisterUser
{
    AuthenticationResultDTO Execute(RegisterUserDTO registerUserDto);
}