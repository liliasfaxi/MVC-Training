using WorkingWithRazor.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product {
            ProductID = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };


        public ActionResult Index()
        {
            return View(myProduct);
        }

    }
}
