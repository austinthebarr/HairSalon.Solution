using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/client/add")]
    public ActionResult Form()
    {
      return View(Stylist.GetAll());
    }

    [HttpPost("/client/add")]
    public ActionResult Submit(string newClient, int stylist)
    {
      Client firstClient = new Client(newClient, stylist);
      firstClient.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/client/index")]
    public ActionResult Index()
    {
      return View(Client.GetAll());
    }
    //Deletes Specific Client by Id
    [HttpGet("/client/{id}/delete")]
      public ActionResult Delete(int id)
    {
      Client thisClient = Client.Find(id);
      return View(thisClient);
    }

    [HttpPost("/client/{id}/delete")]
    public ActionResult DeleteClient(int id)
    {
      Client thisClient = Client.Find(id);
      thisClient.DeleteClient();
      return RedirectToAction("Index");
    }

    //Deletes All Clients
    [HttpGet("/client/deleteAll")]
      public ActionResult DeleteAll()
    {
      return View();
    }

    [HttpPost("/client/deleteAll")]
    public ActionResult DeleteClient()
    {
      Client.DeleteAll();
      return RedirectToAction("Index");
    }

    //Info For Client
    [HttpGet("/client/{id}/info")]
      public ActionResult Info(int id)
    {
      Client thisClient = Client.Find(id);
      return View(thisClient);
    }
  }
}
