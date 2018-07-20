using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

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
    public ActionResult Submit(string newName)
    {
      Stylist newStylist = new Stylist(newName);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylist/index")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }

    [HttpGet("/stylist/{id}/clients")]
    public ActionResult ClientList(int id)
    {
      Stylist currentStylist = Stylist.Find(id);
      List<Client> clientList = currentStylist.GetClients();
      return View(currentStylist);
    }

    //Deletes Specific Stylist by ID
    [HttpGet("/stylist/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      return View(thisStylist) ;
    }

    [HttpPost("/stylist/{id}/delete")]
    public ActionResult DeleteStylist(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.DeleteStylist();
      return RedirectToAction("Index");
    }

    //Deletes All Stylists and their clients
    [HttpGet("/stylist/deleteAll")]
      public ActionResult DeleteAll()
    {
      return View();
    }

    [HttpPost("/stylist/deleteAll")]
    public ActionResult DeleteAllStylists()
    {
      Stylist.DeleteAll();
      return RedirectToAction("Index");
    }

    //Modify Info for Stylist
    [HttpGet("/stylist/{id}/info")]
      public ActionResult Info(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      return View(thisStylist);
    }
    [HttpGet("/stylist/{id}/specialty")]
      public ActionResult specialty(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("selectedStylist", selectedStylist);
      model.Add("stylistSpecialties", stylistSpecialties);
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }

    [HttpPost("/stylist/{id}/info/specialties/new")]
    public ActionResult AddSpecialty(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Specialty specialty = Specialty.Find(Int32.Parse(Request.Form["specialty-id"]));
      stylist.AddSpecialty(specialty);
      return RedirectToAction("index", new {id = stylistId});
    }

    [HttpPost("/stylist/{id}/info")]
    public ActionResult Update(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Edit(Request.Form["newName"]);
      return RedirectToAction("Index");
    }

    // [HttpGet("/stylist/{id}")]
    // public ActionResult Specialty(int id)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist selectedStylist = Stylist.Find(id);
    //   List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
    //   List<Specialty> allSpecialties = Specialty.GetAll();
    //   model.Add("selectedStylist", selectedStylist);
    //   model.Add("stylistSpecialties", stylistSpecialties);
    //   model.Add("allSpecialties", allSpecialties);
    //   return View(model);
    // }
    //
    // [HttpPost("/stylist/{stylistId}/specialties/new")]
    // public ActionResult AddSpecialty(int stylistId)
    // {
    //   Stylist stylist = Stylist.Find(stylistId);
    //   Specialty specialty = Specialty.Find(Int32.Parse(Request.Form["specialty-id"]));
    //   stylist.AddSpecialty(specialty);
    //   return RedirectToAction("Details", new {id = itemId});
    // }


  }
}
