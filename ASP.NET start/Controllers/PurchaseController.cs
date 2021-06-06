using ASP.NET_start.Models;
using ASP.NET_start.PurchaseServiceRef;
using ASP.NET_start.UserServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_start.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            var cart  = GetCart();
            PurchaseServiceRef.PurchaseServiceOf_PurchaseOrderContractClient client = new PurchaseServiceRef.PurchaseServiceOf_PurchaseOrderContractClient();
            PurchaseOrderContract poc = new PurchaseOrderContract();
            var terra = client.GetTerritory();
            SelectList territories = new SelectList(terra, "TerritoryID", "Name");
            ViewBag.terra = territories;
            poc.OrderProducts = cart.Lines.ToArray();
            client.Close();
            return View(poc);
        }
        public ActionResult Purchasing(PurchaseOrderContract poc)
        {
            Cart cart = GetCart();
            poc.OrderProducts = cart.Lines.ToArray();
            
            if (poc.OrderProducts.Count() == 0)
            {
                return View("Index");
            }
            else
            {
                PurchaseServiceRef.PurchaseServiceOf_PurchaseOrderContractClient client = new PurchaseServiceRef.PurchaseServiceOf_PurchaseOrderContractClient();
                UserServiceClient userClient = new UserServiceClient();
                poc.SubTotal = cart.ComputeTotalValue();
                poc.EmployeeID = 256;
                poc.Status = 2;
                poc.ModifiedDate = DateTime.Now;
                if (User.Identity.IsAuthenticated)
                {
                    poc.CustomerID = userClient.GetInfo(User.Identity.Name);
                }
                client.Create(poc);
                cart.Clear();
                userClient.Close();
                client.Close();
                return View();
            }
        }
        public ActionResult UserPurchases()
        {
            UserServiceClient client = new UserServiceClient();
            if (User.Identity.IsAuthenticated) {
                var orders = client.GetOrders(User.Identity.Name);
                return View(orders);
                    }
            else
            {
                return View("Index");
            }
            
        }
        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
       
    }
}