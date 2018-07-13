using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/stylist/add")]
    public ActionResult Form()
    {
      return View();
    }

    [HttpPost("/stylist/add")]
    public ActionResult Submit(string newName, string newSpecialty)
    {
      Stylist newStylist = new Stylist(newName, newSpecialty);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylist/index")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }
  }
}
