using Asp.NetCoreProjectWebApp.Models;
using Asp.NetCoreProjectWebApp.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KitapTuruController : Controller
{
    private readonly UygulamaDbContext _uygulamaDbContext;

    public KitapTuruController(UygulamaDbContext context)
    {
        _uygulamaDbContext = context;
    }
    
    // GET
    public IActionResult Index()
    {
        List<KitapTuru> objKitapTuruList = _uygulamaDbContext.KitapTurleri.ToList();
        return View();
    }
}