using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=austin_barr_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueINameIS_SAME()
    {
      // Arrange, Act
      Client firstClient = new Client("joe",1);
      Client secondClient = new Client("joe",1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void GetAll_ClientsEmpty()
    {
      //act
      int result = Client.GetAll().Count;

      //assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void ClientsSaveToDatabase_Yes()
    {
      //arrange
      Client newClient = new Client("Buzz", 1);
      newClient.Save();
      Client oldClient = new Client("Dana", 2);
      oldClient.Save();


      //act
      List<Client> result = Client.GetAll();
      List<Client> test = new List<Client>{newClient, oldClient};

      CollectionAssert.AreEqual(result, test);
    }

    [TestMethod]
    public void DoesClientHaveID()
    {
      //arrange
      Client firstClient = new Client("Bubba", 2);
      firstClient.Save();
      Client secondClient = new Client("Boo", 2);
      secondClient.Save();

      //act
      Client testClient = Client.GetAll()[1];

      int result = secondClient.GetId();
      int test = testClient.GetId();

      //Assert
      Assert.AreEqual(result, test);
    }
    public void Dispose()
      {
        Stylist.DeleteAll();
        Client.DeleteAll();
      }
  }
}
