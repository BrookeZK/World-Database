using System;
using World;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace World.Models
{
  public class City
  {

    private string _name;
    private string _countryCode;
    private string _district;
    private int _popultion;

    public City(string name, string countryCode, string district, int population)
    {
      _name = name;
      _countryCode = countryCode;
      _district = district;
      _popultion = population;
    }
    public string Name {get => _name; set => _name = value; }
    public string CountryCode {get => _countryCode; set => _countryCode = value; }
    public string District {get => _district; set => _district = value; }
    public int Population {get => _popultion; set => _popultion = value; }

    public static List<City> GetCityByCountryCode(string CountryCode)
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country JOIN city ON Country.Code=City.CountryCode WHERE Code = '" + CountryCode + "';";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string name = rdr.GetString(16);
        string countryCode = rdr.GetString(17);
        string district = rdr.GetString(18);
        int population = rdr.GetInt32(19);
        City newCity = new City(name, countryCode, district, population);
        allCities.Add(newCity);
      }

      conn.Close();

      if(conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
