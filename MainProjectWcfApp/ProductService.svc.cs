using BusinessLogics;
using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfContracts;
using WcfContracts.DataContracts;

namespace MainProjectWcfApp
{
    public class ProductService : IProjectService<ProductContract>
    {
        private ProductionUnitOfWork db = new ProductionUnitOfWork();

        public List<ProductContract> GetAll()
        {
            return Transletors.ProductListToContract(db.Product.GetAllInInventory());
        }

        public ProductPageContract GetPage(int page = 1)
        {
            int PageSize = 10;
            int count = db.Product.GetAll().Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0).Count();
            ProductPageContract mainPage = new ProductPageContract
            {
                Products = Transletors.ProductListToContract(db.Product.GetAll()
                .Where(p => p.ProductInventory.Sum(q => q.Quantity) > 0 && p.StandardCost != 0)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = count,
                    TotalPages = (int)Math.Ceiling((decimal)count / PageSize)
                }
            };
            return mainPage;
        }

        public ProductContract Get(int id)
        {
            Product p = db.Product.Get(id);
            return Transletors.ProductToContract(p);
        }

        public void Create(ProductContract product)
        {
            db.Product.Create(Transletors.ContractToProduct(product));
        }

        public void Update(ProductContract product)
        {
            db.Product.Update(Transletors.ContractToProduct(product));
        }

        public void Delete(int id)
        {
            db.Product.Delete(id);
        }
    }
}