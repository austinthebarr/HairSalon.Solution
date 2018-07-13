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
  public void Dispose()
    {
      Stylist.DeleteAll();
      // Client.DeleteAll();
    }
  }
}
