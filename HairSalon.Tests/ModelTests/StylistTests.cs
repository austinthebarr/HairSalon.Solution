using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{

  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=austin_barr_test;";
    }

  [TestMethod]
  public void GetAll_Stylists_EmptyList_0()
  {
    //act
    int result = Stylist.GetAll().Count;

    //assert
    Assert.AreEqual(0, result);

  }
  [TestMethod]
  public void SavesToDataBase_Yes()
  {
    //arrange
    Stylist newStylist = new Stylist("Peter", "buzz-cut");
    newStylist.Save();

    //act
    List<Stylist> result = Stylist.GetAll();
    List<Stylist> test = new List<Stylist>{newStylist};

    CollectionAssert.AreEqual(result, test);
  }

  [TestMethod]
  public void DoStylistHaveID()
  {
    //arrange
    Stylist newStylist = new Stylist("Dana", "trims");
    newStylist.Save();

    //act
    Stylist secoundStylist = Stylist.GetAll()[0];

    int result = newStylist.GetId();
    int test = secoundStylist.GetId();

    //assert
    Assert.AreEqual(result, test);
  }
  public void Dispose()
    {
      Stylist.DeleteAll();
      // Client.DeleteAll();
    }
  }
}
