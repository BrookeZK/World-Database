using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;


namespace World.Controllers
{
  public class CountriesController : Controller
  {

    [HttpGet("/countries")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }

    [HttpPost("/countries/asc")]
    public ActionResult PopAsc()
    {
      List<Country> allCountries = Country.GetAllByAscPopulation();
      return View("Index", allCountries);
    }

    [HttpPost("/countries/desc")]
    public ActionResult PopDesc()
    {
      List<Country> allCountries = Country.GetAllByDescPopulation();
      return View("Index", allCountries);
    }

    [HttpGet("/countries/{id}")]
    public ActionResult Show(string id)
    {
      Dictionary<string, object> dict = new Dictionary<string, object>();
      List<City> allCities = City.GetCityByCountryCode(id);
      string selectedCountry = Country.GetCountryByCountryCode(id);
      dict.Add("country", selectedCountry);
      dict.Add("cities", allCities);
      return View(dict);
    }
  }
}
