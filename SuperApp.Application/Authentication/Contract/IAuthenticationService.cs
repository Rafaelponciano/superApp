using SuperApp.Domain.User;

namespace SuperApp.Application.Authentication.Contract;

public interface IAuthenticationService
{
    Domain.Authentication.Authentication Register(User user);
    
    Domain.Authentication.Authentication Login(string email, string password);
}