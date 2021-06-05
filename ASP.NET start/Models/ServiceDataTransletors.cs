using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_start.Models
{
    public static class ServiceDataTransletors
    {
        public static PurchaseServiceRef.ProductContract PurchaseProductToProductProduct(ProductServiceRef.ProductContract first)
        {
            PurchaseServiceRef.ProductContract second = new PurchaseServiceRef.ProductContract();
            second.Class = first.Class;
            second.Color = first.Color;
            second.DaysToManufacture = first.DaysToManufacture;
            second.Description = first.Description;
            second.LargePhoto = first.LargePhoto;
            second.ListPrice = first.ListPrice;
            second.ModifiedDate = first.ModifiedDate;
            second.Name = first.Name;
            second.ProductID = first.ProductID;
            second.ProductLine = first.ProductLine;
            second.ProductModelID = first.ProductModelID;
            second.ProductNumber = first.ProductNumber;
            second.SafetyStockLevel = first.SafetyStockLevel;
            second.Size = first.Size;
            second.StandardCost = first.StandardCost;
            second.Style = first.Style;
            second.ThumbNailPhoto = first.ThumbNailPhoto;
            second.Weight = first.Weight;
            return second;
        }
        public static ProductServiceRef.ProductContract ProductProductToPurchaseProduct(PurchaseServiceRef.ProductContract first)
        {
            ProductServiceRef.ProductContract second = new ProductServiceRef.ProductContract();
            second.Class = first.Class;
            second.Color = first.Color;
            second.DaysToManufacture = first.DaysToManufacture;
            second.Description = first.Description;
            second.LargePhoto = first.LargePhoto;
            second.ListPrice = first.ListPrice;
            second.ModifiedDate = first.ModifiedDate;
            second.Name = first.Name;
            second.ProductID = first.ProductID;
            second.ProductLine = first.ProductLine;
            second.ProductModelID = first.ProductModelID;
            second.ProductNumber = first.ProductNumber;
            second.SafetyStockLevel = first.SafetyStockLevel;
            second.Size = first.Size;
            second.StandardCost = first.StandardCost;
            second.Style = first.Style;
            second.ThumbNailPhoto = first.ThumbNailPhoto;
            second.Weight = first.Weight;
            return second;
        }
    }
}