using DbModels.Production;
using System;
namespace BusinessLogics
{
    public class ProductionUnitOfWork : IDisposable
    {
        private Production db = new Production();
        private ProductRepository productRepository;
        private ProductProductPhotoRepository prodprodphotoRepository;
        private ProductPhotoRepository prodphotoRepository;


        public ProductRepository Product
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public ProductProductPhotoRepository ProductProductPhoto
        {
            get
            {
                if (prodprodphotoRepository == null)
                    prodprodphotoRepository = new ProductProductPhotoRepository(db);
                return prodprodphotoRepository;
            }
        }
        public ProductPhotoRepository ProductPhoto
        {
            get
            {
                if (prodphotoRepository == null)
                    prodphotoRepository = new ProductPhotoRepository(db);
                return prodphotoRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}