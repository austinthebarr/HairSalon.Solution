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

    [HttpPost("/stylist/{id}/info")]
    public ActionResult Update(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Edit(Request.Form["newName"]);
      return RedirectToAction("Index");
    }

  }
}
