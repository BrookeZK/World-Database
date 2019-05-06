using System;
using World;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
  public class Country
  {

    private string _code;
    private string _name;
    private string _continent;
    private int _popultion;

    public Country(string code, string name, string continent, int population)
    {
      _code = code;
      _name = name;
      _continent = continent;
      _popultion = population;

    }
    public string Code {get => _code; set => _code = value; }
    public string Name {get => _name; set => _name = value; }
    public string Continent {get => _continent; set => _continent = value; }
    public int Population {get => _popultion; set => _popultion = value; }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        Country newCountry = new Country(code, name, continent, population);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> GetAllByPopulation()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country ORDER BY population;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        Country newCountry = new Country(code, name, continent, population);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }


  }
}
