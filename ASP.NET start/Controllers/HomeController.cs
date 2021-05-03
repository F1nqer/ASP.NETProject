using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbModels.Production;

namespace ASP.NET_start.Controllers
{
    public class HomeController : Controller
    {
        Production db = new Production();

        public ActionResult Index()
        {
            IEnumerable<Product> ProductsWithPhotos = db.Product.Include(p => p.ProductProductPhoto).Include(p => p.ProductProductPhoto.ProductPhoto);
            ViewBag.Products = ProductsWithPhotos;
            return View();  
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}