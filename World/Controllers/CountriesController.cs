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

  }
}
