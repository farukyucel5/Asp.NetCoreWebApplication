using Asp.NetCoreProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KitapController : Controller
{
    private readonly IKitapRepository _kitapRepository;
    private readonly IKitapTuruRepository _kitapTuruRepository;
    public readonly IWebHostEnvironment _webHostEnvironment;

    public KitapController(IKitapRepository context,IKitapTuruRepository kitapTuruRepository, IWebHostEnvironment webHostEnvironment)
    {
        _kitapRepository = context;
        _kitapTuruRepository = kitapTuruRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET
    public IActionResult Index()
    {
        List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
        return View(objKitapList);
    }

    public IActionResult EkleUpdate(int? id)
    {
        IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll().Select(k => new SelectListItem
        {
            Text = k.Ad,
            Value = k.Id.ToString(),
        });
        ViewBag.KitapTuruList = KitapTuruList;
        if (id == null || id == 0)
        {
           
            return View();
        }
        else
        {
            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
            if (kitapVt == null)
                return NotFound();

            return View(kitapVt);
        }
       
    }

    [HttpPost]
    public IActionResult EkleUpdate(Kitap kitap, IFormFile? file)
    {
        string wwwRootPath = _webHostEnvironment.WebRootPath;
        string kitapPath = Path.Combine(wwwRootPath, @"img");
        using(var fileStream=new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        kitap.ResimUrl = @"\img\" + file.FileName;
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            if (kitap.Id == 0)
            {
                _kitapRepository.Add(kitap);
                TempData["Success"] = "A new book has been added successfully";
            }
            else
            {
                _kitapRepository.Update(kitap);
                TempData["Success"] = "The book has been updated successfully";
            }
            
            _kitapRepository.Save();
            
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