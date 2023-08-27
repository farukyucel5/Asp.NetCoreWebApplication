using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KitapTuruController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}