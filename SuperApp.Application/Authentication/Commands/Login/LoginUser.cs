using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;

namespace SuperApp.Application.Authentication.Commands.Login;

public class LoginUser : ILoginUser
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IAutoMapperService _autoMapperService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    public LoginUser(IAuthenticationService authenticationService, IAutoMapperService autoMapperService, IJwtTokenGenerator jwtTokenGenerator)
    {
        _authenticationService = authenticationService;
        _autoMapperService = autoMapperService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResultDTO Execute(LoginUserDTO loginUserDto)
    {
        var authentication = _authenticationService.Login(loginUserDto.Email, loginUserDto.Password);
        
        var authenticationResult = _autoMapperService.Map<Domain.Authentication.Authentication, AuthenticationResultDTO>(authentication);
        
        // authenticationResult.Token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
        
        return authenticationResult;
    }
}