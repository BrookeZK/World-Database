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
    private int _population;
    private double _lifeExpectancy;

    public Country(string code, string name, string continent, int population, double lifeExpectancy)
    {
      _code = code;
      _name = name;
      _continent = continent;
      _population = population;
      _lifeExpectancy = lifeExpectancy;


    }
    public string Code {get => _code; set => _code = value; }
    public string Name {get => _name; set => _name = value; }
    public string Continent {get => _continent; set => _continent = value; }
    public int Population {get => _population; set => _population = value; }
    public double LifeExpectancy {get => _lifeExpectancy; set => _lifeExpectancy = value; }

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
        double lifeExpectancy = 0.0;
        if (!rdr.IsDBNull(7))
        {
          lifeExpectancy = rdr.GetDouble(7);
        }
        Country newCountry = new Country(code, name, continent, population, lifeExpectancy);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> GetAllByAscPopulation()
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
        double lifeExpectancy = 0.0;
        if (!rdr.IsDBNull(7))
        {
          lifeExpectancy = rdr.GetDouble(7);
        }
        Country newCountry = new Country(code, name, continent, population, lifeExpectancy);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static List<Country> GetAllByDescPopulation()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country ORDER BY population DESC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string code = rdr.GetString(0);
        string name = rdr.GetString(1);
        string continent = rdr.GetString(2);
        int population = rdr.GetInt32(6);
        double lifeExpectancy = 0.0;
        if (!rdr.IsDBNull(7))
        {
          lifeExpectancy = rdr.GetDouble(7);
        }
        Country newCountry = new Country(code, name, continent, population, lifeExpectancy);
        allCountries.Add(newCountry);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

    public static string GetCountryByCountryCode(string CountryCode)
    {
      // List<City> countryName = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country JOIN city ON Country.Code=City.CountryCode WHERE Code = '" + CountryCode + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      string name = "";

      while(rdr.Read())
      {
      name = rdr.GetString(1);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return name;
    }
  }
}
