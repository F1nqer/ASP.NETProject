using ASP.NET_start.ProductServiceRef;
using ASP.NET_start.PurchaseServiceRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_start.Models
{
    public class Cart
    {
        private List<CartLine> Carting = new List<CartLine>();
        public void Adding(PurchaseServiceRef.ProductContract product, int quantity)
        {
            CartLine cartline = Carting
                .Where(pi => pi.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (cartline == null)
            {
                Carting.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                cartline.Quantity += 1;
            }
        }
        public void Deleting(ProductServiceRef.ProductContract product)
        {
            Carting.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return Carting.Sum(e => e.Product.StandardCost * e.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get { return Carting; }
        }
        public void Clear()
        {
            Carting.Clear();
        }
    }
}