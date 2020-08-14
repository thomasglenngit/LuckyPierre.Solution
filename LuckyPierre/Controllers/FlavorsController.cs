using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LuckyPierre.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace LuckyPierre.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly LuckyPierreContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 
    public FlavorsController(UserManager<ApplicationUser> userManager, LuckyPierreContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index(string searchFlavor)
    {
      if(!string.IsNullOrEmpty(searchFlavor))
      {
        var searchFlavors = _db.Flavors.Where(flavors => flavors.FlavorName.Contains(searchFlavor)).ToList();                    
        return View(searchFlavors);
      }
      return View(_db.Flavors.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisFlavor = _db.Flavors
          .Include(flavor => flavor.Treats)
          .ThenInclude(join => join.Treat)
          .Include(flavor => flavor.User)
          .FirstOrDefault(flavor => flavor.FlavorId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisFlavor.User.Id : false;
      return View(thisFlavor);
    }
    
    [Authorize]
    public ActionResult Create(string searchTreat)
    {
      if(!string.IsNullOrEmpty(searchTreat))
      {
        var searchTreats = _db.Treats.Where(treats => treats.TreatName.Contains(searchTreat)).ToList();        
        ViewBag.TreatId = searchTreats;
      }
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor, int[] TreatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      if(TreatId.Length !=0)
      {
        foreach(int id in TreatId)
        {
          _db.TreatsFlavors.Add(new TreatFlavor() { TreatId = id, FlavorId = flavor.FlavorId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
      if (thisFlavor == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [Authorize]
    public async Task<ActionResult> AddTreat(int id, string searchTreat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
      if (thisFlavor == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      if(!string.IsNullOrEmpty(searchTreat))
      {
        var searchTreats = _db.Treats.Where(treats => treats.TreatName.Contains(searchTreat)).ToList();        
        ViewBag.TreatList = searchTreats;
      }
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int[] TreatList)
    {
      if(TreatList.Length !=0)
      {
        foreach(int id in TreatList)
        {
          _db.TreatsFlavors.Add(new TreatFlavor() { TreatId = id, FlavorId = flavor.FlavorId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteTreat(int joinId)
    {
      var joinEntry = _db.TreatsFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatsFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    [Authorize]
    public async Task<ActionResult> Delete(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavors => flavors.FlavorId == id);
      if (thisFlavor != null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}