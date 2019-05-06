using System;
using World;

namespace World.Models
{
  public class Country
  {

    private string _code;
    private string _name;
    private string _continent;
    private int _popultion;
    private string _capital;
    private float _lifeExpectancy;

    public Country(string code, string name, string continent, int population, string capital, float lifeExpectancy)
    {
      _code = code;
      _name = name;
      _continent = continent;
      _popultion = population;
      _capital = capital;
      _lifeExpectancy = lifeExpectancy;
    }
    public string Code {get => _code; set => _code = value; }
    public string Name {get => _name; set => _name = value; }
    public string Continent {get => _continent; set => _continent = value; }
    public int Population {get => _popultion; set => _popultion = value; }
    public int Capital {get => _capital; set => _capital = value; }
    public int LifeExpectancy {get => _lifeExpectancy; set => _lifeExpectancy = value; }

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
        int population = rdr.GetInt32(3);
        string capital = rdr.GetString(4);
        float lifeExpectancy = rdr.GetFloat(5);
        Country newCountry = new Country(code, name, continent, population, capital, lifeExpectancy);
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
