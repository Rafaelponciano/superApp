using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;

namespace SuperApp.Application.Authentication.Commands.Login;

public class LoginUser : ILoginUser
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAutoMapperService _autoMapperService;
    
    public LoginUser(IAuthenticationService authenticationService, IAutoMapperService autoMapperService)
    {
        _authenticationService = authenticationService;
        _autoMapperService = autoMapperService;
    }
    public AuthenticationResultDTO Execute(LoginUserDTO loginUserDto)
    {
        var authentication = _authenticationService.Login(loginUserDto.Email, loginUserDto.Password);
        
        var authenticationResult = _autoMapperService.Map<Domain.Authentication.Authentication, AuthenticationResultDTO>(authentication);
        
        return authenticationResult;
    }
}