using Microsoft.AspNetCore.Mvc;

namespace SuperApp.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}