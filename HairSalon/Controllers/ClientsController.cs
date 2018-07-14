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
  }
}
