using ASP.NET_start.Models;
using ASP.NET_start.ProductServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_start.Controllers
{
    public class CartController : Controller
    {
        public CartController() { }
        public ViewResult Index()
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart()
            });
        }

        public RedirectToRouteResult AddToCart(int ProductID)
        {
            ProductServiceRef.ProjectServiceOf_ProductContractClient client = new ProductServiceRef.ProjectServiceOf_ProductContractClient();
            ProductContract product = client.Get(ProductID);
            if (product != null)
            {
                try
                {
                    GetCart().Adding(ServiceDataTransletors.PurchaseProductToProductProduct(product), 1);
                }
                catch
                {
                    return RedirectToAction("Index");
                }

            }
            client.Close();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(int ProductID)
        {
            ProductServiceRef.ProjectServiceOf_ProductContractClient client = new ProductServiceRef.ProjectServiceOf_ProductContractClient();
            ProductContract Productincart = client.Get(ProductID);

            if (Productincart != null)
            {
                GetCart().Deleting(Productincart);
            }
            client.Close();
            return RedirectToAction("Index");
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