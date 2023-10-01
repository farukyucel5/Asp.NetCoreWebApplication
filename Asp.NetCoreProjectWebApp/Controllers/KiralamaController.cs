using Asp.NetCoreProjectWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NetCoreProjectWebApp.Controllers;

public class KiralamaController : Controller
{
    private readonly IKiralamaRepository _kiralamaRepository;
    private readonly IKitapRepository _kitapRepository;
    public readonly IWebHostEnvironment _webHostEnvironment;

    public KiralamaController(IKiralamaRepository context,IKitapRepository kitapRepository, IWebHostEnvironment webHostEnvironment)
    {
        _kiralamaRepository = context;
        _kitapRepository = kitapRepository;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET
    public IActionResult Index()
    {
        List<Kiralama> objKiralamaList = _kiralamaRepository.GetAll(includeProps:"Kitap").ToList();
        return View(objKiralamaList);
    }

    public IActionResult EkleUpdate(int? id)
    {
        IEnumerable<SelectListItem> KitapList = _kitapRepository.GetAll().Select(k => new SelectListItem
        {
            Text = k.KitapAdi,
            Value = k.Id.ToString(),
        });
        ViewBag.KitapList = KitapList;
        if (id == null || id == 0)
        {
           
            return View();
        }
        else
        {
            Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);
            if (kiralamaVt == null)
                return NotFound();

            return View(kiralamaVt);
        }
       
    }

    [HttpPost]
    public IActionResult EkleUpdate(Kiralama kiralama)
    {
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            if (kiralama.Id == 0)
            {
                _kiralamaRepository.Add(kiralama);
                TempData["Success"] = "The book has been rented successfully";
            }
            else
            {
                _kiralamaRepository.Update(kiralama);
                TempData["Success"] = "Renting books state has been updated successfully";
            }
            
            _kiralamaRepository.Save();
            
            return RedirectToAction("Index", "Kiralama");
        }

        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();
        Kiralama? kiralamaVt = _kiralamaRepository.Get(u => u.Id == id);
        if (kiralamaVt == null)
            return NotFound();

        return View(kiralamaVt);
    }
    
    [HttpPost]
    public IActionResult Delete(Kiralama kiralama)
    {
       
        //The code block down below is a backend side validation
        if (ModelState.IsValid)
        {
            _kiralamaRepository.Remove(kiralama);
            _kiralamaRepository.Save();
            TempData["Success"] = "deleted successfully";
            return RedirectToAction("Index", "Kiralama");
        }

        return View();
    }
}