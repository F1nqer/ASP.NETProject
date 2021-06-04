using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfContracts.DataContracts;
using BusinessLogics;

namespace WcfContracts
{
    public static class Transleters
    {
        static ProductionUnitOfWork uow = new ProductionUnitOfWork();
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
        public static PurchaseOrderHeader PurchaseOrderContractToModel(PurchaseOrderContract od)
        {
            PurchaseOrderHeader poh = new PurchaseOrderHeader();
            poh.RevisionNumber = 4;
            poh.Status = od.Status;
            if (uow.SalesPerson.GetAll().Where(x => x.TerritoryID == od.TerritoryID) == null)
            {
                poh.EmployeeID = uow.SalesPerson.GetAll().OrderBy(y => y.SalesLastYear).First().BusinessEntityID;
            }
            else
            {
                poh.EmployeeID = uow.SalesPerson.GetAll().Where(x => x.TerritoryID == od.TerritoryID).OrderBy(y => y.SalesLastYear).First().BusinessEntityID;
            }
            poh.VendorID = 1580;
            poh.ShipMethodID = 3;
            poh.OrderDate = DateTime.Now;
            poh.SubTotal = od.SubTotal;
            poh.TaxAmt = od.SubTotal * (8 / 100);
            poh.Freight = 100;
            poh.TotalDue = poh.SubTotal + poh.TaxAmt + poh.Freight;
            poh.ModifiedDate = DateTime.Now;
            poh.CustomerID = od.CustomerID;
            return poh;
        }
        public static List<TerritoryContract> TerritoriesToContracts(List<SalesTerritory> lst)
        {
            List<TerritoryContract> ltd = new List<TerritoryContract>();
            foreach (var i in lst)
            {
                ltd.Add(new TerritoryContract(i));
            }
            return ltd;
        }
        public static List<PurchaseOrderContract> ModelListToPurchaseOrderContractList(IEnumerable<PurchaseOrderHeader> poh)
        {
            List<PurchaseOrderContract> od = new List<PurchaseOrderContract>();
            foreach (var i in poh)
            {
                od.Add(new PurchaseOrderContract(i));
            }
            return od;
        }
    }
}
