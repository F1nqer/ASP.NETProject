using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class ProductRepository : IRepository<Product>
    {
        private Production db;

        public ProductRepository(Production context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product;
        }

        public IEnumerable<Product> GetAllWithPhotos()
        {
            return db.Product.Include(p => p.ProductProductPhoto).Include("ProductPhoto");
        }

        public IEnumerable<Product> GetAllInInventory()
        {
            return db.Product.Include(p => p.ProductProductPhoto).Where(p => p.ProductInventory.Sum(i => i.Quantity) > 0);
        }


        public Product Get(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product item = db.Product.Find(id);
            if (item != null)
                db.Product.Remove(item);
        }
    }
}
