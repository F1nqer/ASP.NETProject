using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class PurchaseOrderDetailRepository : IRepository<PurchaseOrderDetail>
    {
        private AdventureWorks db;

        public PurchaseOrderDetailRepository(AdventureWorks context)
        {
            this.db = context;
        }

        public IEnumerable<PurchaseOrderDetail> GetAll()
        {
            return db.PurchaseOrderDetail;
        }

        public PurchaseOrderDetail Get(int id)
        {
            return db.PurchaseOrderDetail.Find(id);
        }

        public void Create(PurchaseOrderDetail sod)
        {
            db.PurchaseOrderDetail.Add(sod);
            db.SaveChanges();
        }

        public void Update(PurchaseOrderDetail sod)
        {
            db.Entry(sod).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            PurchaseOrderDetail sod = db.PurchaseOrderDetail.Find(id);
            if (sod != null)
                db.PurchaseOrderDetail.Remove(sod);
            db.SaveChanges();
        }
    }
}
