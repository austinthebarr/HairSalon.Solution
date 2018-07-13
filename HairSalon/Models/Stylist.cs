using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private string _specialty;

    public Stylist(string name, string specialty, int id = 0)
    {
      _id = id;
      _name = name;
      _specialty = specialty;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        return this.GetId().Equals(newStylist.GetId());
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
    public string GetSpecialty()
    {
      return _specialty;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (name, specialty) VALUES (@name, @specialty);";

      cmd.Parameters.Add(new MySqlParameter(@name, _name));
      cmd.Parameters.Add(new MySqlParameter(@specialty, _specialty));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0)
        string SylistName = rdr.GetString(1)
        string StylistSpecialty = rdr.GetSpecialty(2)
        Sylist newStylist = new Stylist(StylistName, StylistSpecialty, StylistId);
        allStylist.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylist;
    }
  }
}
