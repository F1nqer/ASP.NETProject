using DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfContracts.DataContracts;

namespace MainProjectWcfApp
{
    public static class Transleters
    {
        public static ProductContract ProductToContract(Product PModel)
        {
            ProductContract PContract = new ProductContract();
            PContract.Class = PModel.Class;
            PContract.Color = PModel.Color;
            PContract.DaysToManufacture = PModel.DaysToManufacture;
            PContract.ListPrice = PModel.ListPrice;
            PContract.ModifiedDate = PModel.ModifiedDate;
            PContract.Name = PModel.Name;
            PContract.ProductID = PModel.ProductID;
            PContract.ProductLine = PModel.ProductLine;
            PContract.ProductModelID = PModel.ProductModelID;
            PContract.ProductNumber = PModel.ProductNumber;
            PContract.SafetyStockLevel = PModel.SafetyStockLevel;
            PContract.Size = PModel.Size;
            PContract.StandardCost = PModel.StandardCost;
            PContract.Style = PModel.Style;
            PContract.Weight = PModel.Weight;
            PContract.LargePhoto = PModel.ProductProductPhoto.First().ProductPhoto.LargePhoto;
            PContract.ThumbNailPhoto = PModel.ProductProductPhoto.First().ProductPhoto.ThumbNailPhoto;
            if (PModel.ProductModel == null || PModel.ProductModel.ProductModelProductDescriptionCulture.Count() < 1)
            {
                PContract.Description = "null";
            }
            else
            {
                PContract.Description = PModel.ProductModel.ProductModelProductDescriptionCulture.First().ProductDescription.Description;
            }
            return PContract;
        }
        public static List<ProductContract> ProductListToContract(IEnumerable<Product> PList)
        {
            List<ProductContract> PContractList = new List<ProductContract>();
            foreach (Product PModel in PList)
            {
                ProductContract PContract = new ProductContract();
                PContract.Class = PModel.Class;
                PContract.Color = PModel.Color;
                PContract.DaysToManufacture = PModel.DaysToManufacture;
                PContract.ListPrice = PModel.ListPrice;
                PContract.ModifiedDate = PModel.ModifiedDate;
                PContract.Name = PModel.Name;
                PContract.ProductID = PModel.ProductID;
                PContract.ProductLine = PModel.ProductLine;
                PContract.ProductModelID = PModel.ProductModelID;
                PContract.ProductNumber = PModel.ProductNumber;
                PContract.SafetyStockLevel = PModel.SafetyStockLevel;
                PContract.Size = PModel.Size;
                PContract.StandardCost = PModel.StandardCost;
                PContract.Style = PModel.Style;
                PContract.Weight = PModel.Weight;
                PContract.LargePhoto = PModel.ProductProductPhoto.First().ProductPhoto.LargePhoto;
                PContract.ThumbNailPhoto = PModel.ProductProductPhoto.First().ProductPhoto.ThumbNailPhoto;
                if (PModel.ProductModel == null || PModel.ProductModel.ProductModelProductDescriptionCulture.Count() < 1)
                {
                    PContract.Description = "null";
                }
                else
                {
                    PContract.Description = PModel.ProductModel.ProductModelProductDescriptionCulture.First().ProductDescription.Description;
                }
                PContractList.Add(PContract);
            }
            return PContractList;
        }
        public static Product ContractToProduct(ProductContract PModel)
        {
            Product PContract = new Product();
            PContract.Class = PModel.Class;
            PContract.Color = PModel.Color;
            PContract.DaysToManufacture = PModel.DaysToManufacture;
            PContract.ListPrice = PModel.ListPrice;
            PContract.ModifiedDate = PModel.ModifiedDate;
            PContract.Name = PModel.Name;
            PContract.ProductID = PModel.ProductID;
            PContract.ProductLine = PModel.ProductLine;
            PContract.ProductModelID = PModel.ProductModelID;
            PContract.ProductNumber = PModel.ProductNumber;
            PContract.SafetyStockLevel = PModel.SafetyStockLevel;
            PContract.Size = PModel.Size;
            PContract.StandardCost = PModel.StandardCost;
            PContract.Style = PModel.Style;
            PContract.Weight = PModel.Weight;
            return PContract;
        }
    }
}