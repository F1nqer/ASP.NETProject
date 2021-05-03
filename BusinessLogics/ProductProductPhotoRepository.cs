using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class ProductProductPhotoRepository : IRepository<ProductProductPhoto>
    {
        private Production db;

        public ProductProductPhotoRepository(Production context)
        {
            this.db = context;
        }

        public IEnumerable<ProductProductPhoto> GetAll()
        {
            return db.ProductProductPhoto.Include(p => p.ProductPhoto);
        }

        public ProductProductPhoto Get(int id)
        {
            return db.ProductProductPhoto.Find(id);
        }

        public void Create(ProductProductPhoto item)
        {
            db.ProductProductPhoto.Add(item);
        }

        public void Update(ProductProductPhoto item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductProductPhoto item = db.ProductProductPhoto.Find(id);
            if (item != null)
                db.ProductProductPhoto.Remove(item);
        }
    }
}
