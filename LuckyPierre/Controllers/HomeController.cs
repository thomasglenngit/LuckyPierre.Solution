using Microsoft.AspNetCore.Mvc;

namespace LuckyPierre.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}