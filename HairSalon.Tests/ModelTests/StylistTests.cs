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
    Stylist newStylist = new Stylist("Peter");
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
    Stylist newStylist = new Stylist("Dana");
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
    Stylist testStylist = new Stylist("Dana");
    testStylist.Save();
    Stylist test2Stylist = new Stylist("Peter");
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
    Stylist testStylist = new Stylist("Dana");
    testStylist.Save();
    Stylist test2Stylist = new Stylist("Peter");
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
    Stylist newStylist1 = new Stylist("Donna");
    newStylist1.Save();
    Stylist newStylist2 = new Stylist("Patti");
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
  [TestMethod]
   public void Edit_UpdatesNameOfStylist()
   {
     //Arrange
     Stylist newStylist = new Stylist("Dan");
     newStylist.Save();

     //Act
     string newName = "Peter";
     newStylist.Edit(newName);

     string result = Stylist.Find(newStylist.GetId()).GetName();

     //Assert
     Assert.AreEqual(newName, result);
   }

   [TestMethod]
    public void AddaStylistToASpecialty()
    {
      //Arrange
      Stylist testStylist = new Stylist("Peter");
      testStylist.Save();

      Specialty testSpecialty = new Specialty("Color");
      testSpecialty.Save();

      //Act
      testStylist.AddSpecialty(testSpecialty);

      List<Specialty> result = testStylist.GetSpecialties();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

  public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
