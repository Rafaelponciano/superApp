using SuperApp.Application.Authentication.Contract;
using SuperApp.Application.Heroes.Contract;
using SuperApp.Application.Interfaces;
using SuperApp.Application.Users.Contract;
using SuperApp.Domain.Authentication;
using SuperApp.Domain.User;

namespace SuperApp.Infrastructure.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IAutoMapperService _autoMapperService;
    
    public AuthenticationService(IUserService userService, IJwtTokenGenerator jwtTokenGenerator, IAutoMapperService autoMapperService)
    {
        _userService = userService;
        _jwtTokenGenerator = jwtTokenGenerator;
        _autoMapperService = autoMapperService;
    }

    public Authentication Register(User user)
    {
        var dbUser = _userService.GetByEmail(user.Email);
        if (dbUser is not null)
            throw new Exception("AlreadyExist");
        
        user = _userService.Insert(user);
        var authentication = _autoMapperService.Map<User, Authentication>(user);
        authentication.Token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

        return authentication;
    }

    public Authentication Login(string email, string password)
    {
        if (_userService.CheckPassword(email, password))
        {
            var user = _userService.GetByEmail(email);
            if (user is null)
                throw new Exception("UserNotFound");
            
            var authentication = _autoMapperService.Map<User, Authentication>(user);
            authentication.Token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            
            return authentication;
        }
        else
        {
            throw new Exception("InvalidCredentials");
        }
    }
} 