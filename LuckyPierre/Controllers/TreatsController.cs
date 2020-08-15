using Microsoft.AspNetCore.Mvc;
using LuckyPierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace LuckyPierre.Controllers
{
  public class TreatsController : Controller
  {
    private readonly LuckyPierreContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

    public  TreatsController(UserManager<ApplicationUser> userManager, LuckyPierreContext db)
    {
      _userManager = userManager;
      _db = db;
    } 

    public ActionResult Index(string searchTreat)
    {
      if(!string.IsNullOrEmpty(searchTreat))
      {
        var searchTreats = _db.Treats.Where(treats => treats.TreatName.Contains(searchTreat)).ToList();                    
        return View(searchTreats);
      }
      return View(_db.Treats.ToList()); //Put the treats in a list.
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      _db.Treats.Add(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTreat  = _db.Treats
        .Include(treat => treat.Flavors)
        .ThenInclude(join => join.Flavor)
        .Include(treat => treat.User)
        .FirstOrDefault(treats => treats.TreatId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisTreat.User.Id : false;
      return View(thisTreat);
    }
    
    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id);
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id);
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public async Task<ActionResult> AddFlavor(int id, string searchFlavor)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisTreat = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(treats => treats.TreatId == id); //Data mining
      if (thisTreat == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      if(!string.IsNullOrEmpty(searchFlavor))
      {
        var searchFlavors = _db.Flavors.Where(flavors => flavors.FlavorName.Contains(searchFlavor)).ToList();
        ViewBag.FlavorId = searchFlavors;
      }
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int [] FlavorId)
    {
      if(FlavorId.Length != 0)
      {
        foreach(int id in FlavorId)
        {
          _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = id, TreatId = treat.TreatId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}