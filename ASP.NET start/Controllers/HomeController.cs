using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbModels.Production;
using BusinessLogics;

namespace ASP.NET_start.Controllers
{
    public class HomeController : Controller
    {

        ProductionUnitOfWork PUoW = new ProductionUnitOfWork();

        public ActionResult Index()
        {
            IEnumerable<Product> ProductsWithPhotos = PUoW.Product.GetAllInInventory();
            return View(ProductsWithPhotos);  
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