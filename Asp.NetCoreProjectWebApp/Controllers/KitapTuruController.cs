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
        return View(objKitapTuruList);
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(KitapTuru kitapTuru)
    {
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _uygulamaDbContext.KitapTurleri.Add(kitapTuru);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index", "KitapTuru");
        }

        return View();
    }

    public IActionResult Update(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        KitapTuru? kitapTuruVt = _uygulamaDbContext.KitapTurleri.Find(id);
        if (kitapTuruVt == null)
            return NotFound();

        return View(kitapTuruVt);
    }
    
    [HttpPost]
    public IActionResult Update(KitapTuru kitapTuru)
    {
       
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _uygulamaDbContext.KitapTurleri.Update(kitapTuru);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index", "KitapTuru");
        }

        return View();
    }
}