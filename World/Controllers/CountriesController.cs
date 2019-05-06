using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using World.Models;
using System;

namespace World.Controllers
{
  public class CountriesController : Controller
  {

    [HttpGet("/countries")]
    public ActionResult Index()
    {
      // List<Category> allCategories = Category.GetAll();
      // return View(allCategories);
    }

  }
}
