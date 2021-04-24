using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DbModels.Production;
using DbModels.Sales;
using DbModels.Person;
namespace KaspiDBStart
{
    class Program
    {
        static void Main(string[] args)
        {
            //Production
            MainRepository<Product> ProductionProductRep = new MainRepository<Product>(new Production());
            MainRepository<ProductCategory> ProductionProductCategoryRep = new MainRepository<ProductCategory>(new Production());
            MainRepository<ProductDescription> ProductionProductDescriptionRep = new MainRepository<ProductDescription>(new Production());
            MainRepository<ProductInventory> ProductionProductInventoryRep = new MainRepository<ProductInventory>(new Production());
            MainRepository<ProductListPriceHistory> ProductionProductListPriceHistoryRep = new MainRepository<ProductListPriceHistory>(new Production());
            MainRepository<ProductPhoto> ProductionProductPhotoRep = new MainRepository<ProductPhoto>(new Production());
            MainRepository<ProductProductPhoto> ProductionProductProductPhotoRep =  new MainRepository<ProductProductPhoto>(new Production());

            //Sales
            MainRepository<Customer> SalesCustomerRep = new MainRepository<Customer>(new Sales());
            MainRepository<SalesPerson> SalesPersonRep = new MainRepository<SalesPerson>(new Sales());
            MainRepository<SalesOrderHeader> SalesOrderHeaderRep = new MainRepository<SalesOrderHeader>(new Sales());
            MainRepository<SalesOrderDetail> SSalesOrderDetailRep = new MainRepository<SalesOrderDetail>(new Sales());
            MainRepository<ShoppingCartItem> ShoppingCartItemRep = new MainRepository<ShoppingCartItem>(new Sales());
            MainRepository<SalesTerritory> SalesTerritoryRep = new MainRepository<SalesTerritory>(new Sales());

            //Persons
            MainRepository<Address> PersonAddressRep = new MainRepository<Address>(new Persons());
            MainRepository<BusinessEntity> PersonBusinessEntityRep = new MainRepository<BusinessEntity>(new Persons());
            MainRepository<BusinessEntityAddress> PersonBusinessEntityAddressRep = new MainRepository<BusinessEntityAddress>(new Persons());
            MainRepository<PersonPhone> PersonPhoneRep = new MainRepository<PersonPhone>(new Persons());
            MainRepository<StateProvince> PersonStateProvinceRep = new MainRepository<StateProvince>(new Persons());

            IEnumerable<Product> ProductionProduct = ProductionProductRep.Read();

                foreach (Product u in ProductionProduct)
                {
                    Console.WriteLine($"{u.Name} with number {u.ProductNumber}");
                }
            
            Console.ReadKey();
        }
    }
}
