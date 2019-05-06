using System;
using World;

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


  }
}
