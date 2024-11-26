using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.Authentication.Commands.Login;
using SuperApp.Application.Authentication.Commands.Register;

namespace SuperApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IRegisterUser _registerUser;
    private readonly ILoginUser _loginUser;

    public AuthenticationController(IRegisterUser registerUser, ILoginUser loginUser)
    {
        _registerUser = registerUser;
        _loginUser = loginUser;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUserDTO user)
    {
        var auth = _loginUser.Execute(user);
        return Ok(auth);
    }
    
    [HttpPost("register")]
    public IActionResult Register(RegisterUserDTO user)
    {
        var auth = _registerUser.Execute(user);
        return Ok(auth);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}