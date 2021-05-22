using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbModels.Production;
using BusinessLogics;
using ASP.NET_start.ProductServiceRef;

namespace ASP.NET_start.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            ProductServiceRef.ProjectServiceOf_ProductClient client = new ProjectServiceOf_ProductClient();
            IEnumerable<Product> ProductsWithPhotos = client.GetAll();
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