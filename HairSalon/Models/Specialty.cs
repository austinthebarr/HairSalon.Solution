using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _id;
    private string _description;

    public Specialty(string description, int id = 0)
    {
      _id = id;
      _description = description;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if(!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        return this.GetId().Equals(newSpecialty.GetId());
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

    public string GetDescription()
    {
      return _description;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void DeleteSpecialty()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties WHERE id = @ThisId;";

      MySqlParameter specialtyId = new MySqlParameter();
      specialtyId.ParameterName = "@ThisId";
      specialtyId.Value = _id;
      cmd.Parameters.Add(specialtyId);

      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyDescription = "";
        if(!rdr.IsDBNull(1))
        {
         SpecialtyDescription = rdr.GetString(1);
        }
        Specialty newSpecialty = new Specialty(SpecialtyDescription, SpecialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@description);";

      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@description";
      specialty.Value = _description;
      cmd.Parameters.Add(specialty);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
