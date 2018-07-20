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

    //Info and Add Specialty to Stylist
    // [HttpGet("/specialty/{id}/info")]
    //   public ActionResult Info(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>{};
    //   Specialty thisSpecialty = Specialty.Find(id);
    //   List<Stylist> allStylists = Stylist.GetAll();
    //   model.Add("stylists", allStylists);
    //   model.Add("thisSpecialty", thisSpecialty);
    //   model.Add("specialtyId", id);
    //   return View(model);
    // }
    //
    // [HttpPost("/specialty/{id}/info")]
    // public ActionResult AlterClient(int id)
    // {
    //   Specialty thisSpecialty = Specialty.Find(id);
    //   Request.Form["newStylist"].stylistAdded.AddSpecialty(thisSpecialty);
    //   return RedirectToAction("Index");
    // }
  }
}
