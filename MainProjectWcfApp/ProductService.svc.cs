using BusinessLogics;
using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DbModels.DataContracts;

namespace MainProjectWcfApp
{
    public class ProductService : IProjectService<ProductContract>
    {
        private ProductionUnitOfWork db = new ProductionUnitOfWork();

        public IEnumerable<ProductContract> GetAll()
        {
            return Transleters.ProductListToContract(db.Product.GetAll());
        }

        public IEnumerable<ProductContract> GetAllInInventory()
        {
            return Transleters.ProductListToContract(db.Product.GetAllInInventory());
        }

        public ProductContract Get(int id)
        {
            Product p = db.Product.Get(id);
            return Transleters.ProductToContract(p);
        }

        public void Create(ProductContract product)
        {
            db.Product.Create(Transleters.ContractToProduct(product));
        }

        public void Update(ProductContract product)
        {
            db.Product.Update(Transleters.ContractToProduct(product));
        }

        public void Delete(int id)
        {
            db.Product.Delete(id);
        }
    }
}