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

  [TestMethod]
  public void CanIFindaStylistById_InDatabase_Find()
  {
    //arrange
    Stylist testStylist = new Stylist("Dana", "trims");
    testStylist.Save();
    Stylist test2Stylist = new Stylist("Peter", "buzz-cut");
    test2Stylist.Save();

    //act
    Stylist foundStylist = Stylist.Find(testStylist.GetId());

    //assert
    Assert.AreEqual(foundStylist, testStylist);

  }

  [TestMethod]
  public void CanIFindaStylistById_InDatabase_Find2()
  {
    //arrange
    Stylist testStylist = new Stylist("Dana", "trims");
    testStylist.Save();
    Stylist test2Stylist = new Stylist("Peter", "buzz-cut");
    test2Stylist.Save();

    //act
    Stylist foundStylist = Stylist.Find(test2Stylist.GetId());

    //assert
    Assert.AreEqual(foundStylist, test2Stylist);

  }
  [TestMethod]
  public void CanIDeleteaSpecificStylistbyID()
  {
    //Arrange
    Stylist newStylist1 = new Stylist("Donna", "Coloring");
    newStylist1.Save();
    Stylist newStylist2 = new Stylist("Patti", "LongHair");
    newStylist2.Save();
    Assert.IsTrue(Stylist.GetAll().Count == 2);

    //Act
    newStylist1.DeleteStylist();
    List<Stylist> expectedList = new List<Stylist> {newStylist2};

    //Assert
    List<Stylist> outputList = Stylist.GetAll();
    Assert.IsTrue(outputList.Count == 1);
    CollectionAssert.AreEqual(expectedList, outputList);
  }

  public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
