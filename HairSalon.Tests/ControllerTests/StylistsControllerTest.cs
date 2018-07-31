using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistsControllerTest
  {
    [TestMethod]
    public void Index_usesStylistModel()
    {
      //arrange
      ViewResult indexView = new StylistController().Index() as ViewResult;

      //act
      var result = indexView.ViewData.Model;

      //assert
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }

    [TestMethod]
    public void FormReturnsCorrectView()
    {
      //Arrange\
      StylistController controller = new StylistController();

      //Act
      ActionResult formView = controller.Form();

      //Assert
      Assert.IsInstanceOfType(formView, typeof(ViewResult));
    }
  }
}
