using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers;

public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
