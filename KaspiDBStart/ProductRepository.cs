using DbModels.Production;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KaspiDBStart
{
    public class ProductRepository<TEntity> : IRepository<Product> 
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public ProductRepository()
        {
            _context = new Production();
            db = new Production();
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<Product> GetWithPhotos()
        {
            IQueryable<Product> ProductsWithPhotos = from product in db.Product
                                     join productproductphoto in db.ProductProductPhoto on product.ProductID equals productproductphoto.ProductID
                                     join productphoto in db.ProductPhoto on productproductphoto.ProductPhotoID equals productphoto.ProductPhotoID
                                     select product;
            return ProductsWithPhotos;
        }
            
        public IEnumerable<TEntity> Read()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Read(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Dispose()
        {

        }
    }
}