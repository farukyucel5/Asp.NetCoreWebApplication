using Asp.NetCoreProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KitapController : Controller
{
    private readonly IKitapRepository _kitapRepository;

    public KitapController(IKitapRepository context)
    {
        _kitapRepository = context;
    }

    // GET
    public IActionResult Index()
    {
        List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
        return View(objKitapList);
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Kitap kitap)
    {
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _kitapRepository.Add(kitap);
            _kitapRepository.Save();
            TempData["Success"] = "A new book has been added successfully";
            return RedirectToAction("Index", "Kitap");
        }

        return View();
    }

    public IActionResult Update(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
        if (kitapVt == null)
            return NotFound();

        return View(kitapVt);
    }
    
    [HttpPost]
    public IActionResult Update(Kitap kitap)
    {
       
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
           _kitapRepository.Update(kitap);
           _kitapRepository.Save();
            TempData["Success"] = "updated successfully";
            return RedirectToAction("Index", "Kitap");
        }

        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
        if (kitapVt == null)
            return NotFound();

        return View(kitapVt);
    }
    
    [HttpPost]
    public IActionResult Delete(Kitap kitap)
    {
       
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _kitapRepository.Remove(kitap);
            _kitapRepository.Save();
            TempData["Success"] = "deleted successfully";
            return RedirectToAction("Index", "Kitap");
        }

        return View();
    }
}