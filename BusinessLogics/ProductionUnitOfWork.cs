using DbModels.ContextModels;
using System;
namespace BusinessLogics
{
    public class ProductionUnitOfWork : IDisposable
    {
        private AdventureWorks db = new AdventureWorks();
        private ProductRepository productRepository;
        private ProductProductPhotoRepository prodprodphotoRepository;
        private ProductPhotoRepository prodphotoRepository;
        private PurchaseOrderHeaderRepository orderheaderRepository;
        private SalesPersonRepository salespersonRepository;
        private PurchaseOrderDetailRepository orderdetailRepository;
        private TerritoryRepository salesterritoryRepository;


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

        public PurchaseOrderHeaderRepository OrderHeader
        {
            get
            {
                if (orderheaderRepository == null)
                    orderheaderRepository = new PurchaseOrderHeaderRepository(db);
                return orderheaderRepository;
            }
        }
        public PurchaseOrderDetailRepository OrderDetail
        {
            get
            {
                if (orderdetailRepository == null)
                    orderdetailRepository = new PurchaseOrderDetailRepository(db);
                return orderdetailRepository;
            }
        }
        public SalesPersonRepository SalesPerson
        {
            get
            {
                if (salespersonRepository == null)
                    salespersonRepository = new SalesPersonRepository(db);
                return salespersonRepository;
            }
        }
        public TerritoryRepository SalesTerritory
        {
            get
            {
                if (salesterritoryRepository == null)
                    salesterritoryRepository = new TerritoryRepository(db);
                return salesterritoryRepository;
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