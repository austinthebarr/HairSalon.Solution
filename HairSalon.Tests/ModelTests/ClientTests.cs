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

    [TestMethod]
    public void CanIFindClientWithID_YES()
    {
      //arrange
      Client firstClient = new Client("Daniel", 2);
      firstClient.Save();
      Client secondClient = new Client("Bobby Lee", 2);
      secondClient.Save();
      //act
      Client foundClient = Client.Find(secondClient.GetId());
      //Assert
      Assert.AreEqual(foundClient, secondClient);
    }

    [TestMethod]
    public void CanIDeleteaSpecificClientbyID()
    {
      //Arrange
      Client newClient1 = new Client("Phillip", 2);
      newClient1.Save();
      Client newClient2 = new Client("Gregory", 2);
      newClient2.Save();
      Assert.IsTrue(Client.GetAll().Count == 2);

      //Act
      newClient1.DeleteClient();
      List<Client> expectedList = new List<Client> {newClient2};

      //Assert
      List<Client> outputList = Client.GetAll();
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
