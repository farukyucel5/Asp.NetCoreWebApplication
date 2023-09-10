using Asp.NetCoreProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KitapController : Controller
{
    private readonly IKitapRepository _kitapRepository;
    private readonly IKitapTuruRepository _kitapTuruRepository;

    public KitapController(IKitapRepository context,IKitapTuruRepository kitapTuruRepository)
    {
        _kitapRepository = context;
        _kitapTuruRepository = kitapTuruRepository;
    }

    // GET
    public IActionResult Index()
    {
        List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
        return View(objKitapList);
    }

    public IActionResult Ekle()
    {
        IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll().Select(k => new SelectListItem
        {
            Text = k.Ad,
            Value = k.Id.ToString(),
        });
        ViewBag.KitapTuruList = KitapTuruList;
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