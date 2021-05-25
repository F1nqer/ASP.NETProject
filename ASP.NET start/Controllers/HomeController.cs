using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbModels.Production;
using BusinessLogics;
using ASP.NET_start.ProductServiceRef;
using DbModels.DataContracts;

namespace ASP.NET_start.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            ProductServiceRef.ProjectServiceOf_ProductContractClient client = new ProjectServiceOf_ProductContractClient();
            IEnumerable<ProductContract> ProductsWithPhotos = client.GetAll();
            client.Close();
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