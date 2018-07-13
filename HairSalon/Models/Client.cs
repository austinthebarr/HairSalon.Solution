using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;

    public Client(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        return this.GetId().Equals(newClient.GetId());
      }
    }
    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }

  }
}
