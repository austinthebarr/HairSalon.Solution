using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public SylistTests : IDisposable
  {
    DBConfiguration.ConnectionString = "server=localhost; user id=root;password=root;port=8889;database=austin_barr_test;";
  }

  
  public void Dispose()
    {
      Sylist.DeleteAll();
      Client.DeleteAll();
    }
}
