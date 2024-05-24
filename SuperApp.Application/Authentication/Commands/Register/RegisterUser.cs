using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;
using SuperApp.Domain.User;

namespace SuperApp.Application.Authentication.Commands.Register;

public class RegisterUser : IRegisterUser
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAutoMapperService _autoMapperService;
    
    public RegisterUser(IAuthenticationService authenticationService, IAutoMapperService autoMapperService)
    {
        _authenticationService = authenticationService;
        _autoMapperService = autoMapperService;
    }
    
    public AuthenticationResultDTO Execute(RegisterUserDTO registerUserDto)
    {
        try
        {
            if (!registerUserDto.Password.Equals(registerUserDto.ConfirmPassword))
            {
                throw new Exception();
            }

            var user = _autoMapperService.Map<RegisterUserDTO, User>(registerUserDto);
            var authentication = _authenticationService.Register(user);
            
            var authenticationResult = _autoMapperService.Map<Domain.Authentication.Authentication, AuthenticationResultDTO>(authentication);

            return authenticationResult;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}