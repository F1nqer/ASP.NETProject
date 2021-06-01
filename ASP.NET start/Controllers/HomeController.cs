using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogics;
using ASP.NET_start.ProductServiceRef;
using DbModels;

namespace ASP.NET_start.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index(int page = 1)
        {
            ProjectServiceOf_ProductContractClient client = new ProjectServiceOf_ProductContractClient();
            ProductPageContract productPage = client.GetPage(page);
            client.Close();
            return View(productPage);
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