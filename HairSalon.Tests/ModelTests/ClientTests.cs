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
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      // Arrange, Act
      Client firstClient = new Client("joe",1);
      Client secondClient = new Client("joe",1);

      // Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    public void Dispose()
      {
        Stylist.DeleteAll();
        Client.DeleteAll();
      }
  }
}
