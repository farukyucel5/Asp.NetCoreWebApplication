using Asp.NetCoreProjectWebApp.Models;
using Asp.NetCoreProjectWebApp.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreProjectWebApp.Controllers;

[Authorize(Roles = UserRoles.Role_Admin)]
public class KitapTuruController : Controller
{
    private readonly IKitapTuruRepository _kitapTuruRepository;

    public KitapTuruController(IKitapTuruRepository context)
    {
        _kitapTuruRepository = context;
    }

    // GET
    public IActionResult Index()
    {
        List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
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
            _kitapTuruRepository.Add(kitapTuru);
            _kitapTuruRepository.Save();
            TempData["Success"] = "A new genre has been added successfully";
            return RedirectToAction("Index", "KitapTuru");
        }

        return View();
    }

    public IActionResult Update(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
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
           _kitapTuruRepository.Update(kitapTuru);
           _kitapTuruRepository.Save();
            TempData["Success"] = "updated successfully";
            return RedirectToAction("Index", "KitapTuru");
        }

        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
        if (kitapTuruVt == null)
            return NotFound();

        return View(kitapTuruVt);
    }
    
    [HttpPost]
    public IActionResult Delete(KitapTuru kitapTuru)
    {
       
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _kitapTuruRepository.Remove(kitapTuru);
            _kitapTuruRepository.Save();
            TempData["Success"] = "deleted successfully";
            return RedirectToAction("Index", "KitapTuru");
        }

        return View();
    }
}