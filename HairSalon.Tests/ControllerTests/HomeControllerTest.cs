using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
    [TestMethod]
    public void Index_ReturnsCorrectView()
    {
      //arrange
      HomeController controller = new HomeController();

      //act
      ActionResult indexView = controller.Index();

      //assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
