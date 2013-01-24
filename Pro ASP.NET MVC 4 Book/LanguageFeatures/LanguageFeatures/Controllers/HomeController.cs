using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            return "Navigate to a URL to show an example";
        }

        //Shows how PROPERTIES work
        public ViewResult AutoProperty()
        {
            //create a new Product object
            Product myProduct = new Product();

            //set the property value
            myProduct.Name = "Kayak";

            //get the property
            string productName = myProduct.Name;

            //generate the view
            return View("Result",
                (object)String.Format("Product name: {0}", productName));
        }

        //Shows how to use the OBJECT INITIALIZER FEATURE
        public ViewResult CreateProduct()
        {
            //create and populate a new Product object
            Product myProduct = new Product
            {
                ProductID = 100, Name = "Kayak", Description = "A boat for one person",
                Price = 275M, Category = "Watersports"
            };

            return View("Result",
                (object)String.Format("Category: {0}", myProduct.Category));
        }

        //shows how to INITIALIZE COLLECTIONS AND ARRAYS
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string,int> {
                { "apple", 10}, {"orange", 20}, {"plum", 30}
            };

            return View("Result",
                (object)stringArray[1]);
        }

        //Shows how to use an EXTENSION METHOD
        public ViewResult UseFilterExtensionMethod() {

            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M},
                }
            };

            //get the total value of the products in the cart
            decimal total = 0;

            foreach ( Product prod in products.Filter( prod => prod.Category == "Soccer" || prod.Price > 20 ) ) {
                total += prod.Price;
            } //FilterByCategory is part of MyExtensionMethods class, NOT the ShoppingCart class

            return View("Result",
                (object)String.Format("Total: {0}", total));
        }

        //Shows how to use ANONYMOUS TYPES
        public ViewResult CreateAnonArray() {

            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
            };

            StringBuilder result = new StringBuilder();
            foreach ( var item in oddsAndEnds ) {
                result.Append( item.Name ).Append( " " );
            }

            return View( "Result", ( object )result.ToString() );

        }

        //Shows how to use LINQ (Language Integrated Queries) (List of LINQ extension methods on page 94) 
        public ViewResult FindProducts() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                                 };

            var foundProducts = products.OrderByDescending( e => e.Price )
                                    .Take( 3 )
                                    .Select( e => new {
                                        e.Name,
                                        e.Price
                                    } );

            //This line shows how a deferred extension method will alter the OrderByDescending result based on the change.
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();
            foreach ( var p in foundProducts ) {
                result.AppendFormat( "Price: {0} ", p.Price );
            }

            return View( "Result", (object)result.ToString() );
        }



    }
}
