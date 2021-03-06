using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=austin_barr_test;";
    }

    public void Dispose()
      {
        Specialty.DeleteAll();
      }

    [TestMethod]
    public void Equals_ReturnsTrueINameIS_SAME()
    {
      // Arrange, Act
      Specialty firstSpecialty = new Specialty("LongHair",1);
      Specialty secondSpecialty = new Specialty("LongHair",1);

      // Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void SpecialtiesEmpty_GetAllWorks()
    {
      //act
      int result = Specialty.GetAll().Count;

      //assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void SavesToDataBase_Yes()
    {
      //arrange
      Specialty newSpecialty = new Specialty("HighLights");
      newSpecialty.Save();

      //act
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> test = new List<Specialty>{newSpecialty};

      CollectionAssert.AreEqual(result, test);
    }
    [TestMethod]
    public void DoSpecialtyHaveID()
    {
      //arrange
      Specialty newSpecialty = new Specialty("trims");
      newSpecialty.Save();

      //act
      Specialty secoundSpecialty = Specialty.GetAll()[0];

      int result = newSpecialty.GetId();
      int test = secoundSpecialty.GetId();

      //assert
      Assert.AreEqual(result, test);
    }
    [TestMethod]
    public void FindSpecialtyinDatabase()
    {
      //arrange
      Specialty testSpecialty = new Specialty("trims");
      testSpecialty.Save();
      Specialty test2Specialty = new Specialty("buzz-cut");
      test2Specialty.Save();

      //act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

      //assert
      Assert.AreEqual(foundSpecialty, testSpecialty);

    }
  }
}
