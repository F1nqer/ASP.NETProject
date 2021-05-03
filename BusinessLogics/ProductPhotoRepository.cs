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
    public class ProductPhotoRepository : IRepository<ProductPhoto>
    {
        private Production db;

        public ProductPhotoRepository(Production context)
        {
            this.db = context;
        }

        public IEnumerable<ProductPhoto> GetAll()
        {
            return db.ProductPhoto;
        }
       


        public ProductPhoto Get(int id)
        {
            return db.ProductPhoto.Find(id);
        }

        public void Create(ProductPhoto item)
        {
            db.ProductPhoto.Add(item);
        }

        public void Update(ProductPhoto item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            ProductPhoto item = db.ProductPhoto.Find(id);
            if (item != null)
                db.ProductPhoto.Remove(item);
        }
    }
}