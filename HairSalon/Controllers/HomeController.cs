using Microsoft.AspNetCore.Mvc;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [Produces("text/html")]
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
