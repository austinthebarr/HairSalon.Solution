using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialty/add")]
    public ActionResult Form()
    {
      return View();
    }

    [HttpPost("/specialty/add")]
    public ActionResult Submit(string newDescription)
    {
      Specialty newSpecialty = new Specialty(newDescription);
      newSpecialty.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialty/index")]
    public ActionResult Index()
    {
      return View(Specialty.GetAll());
    }
  }
}
