using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class PurchaseOrderHeaderRepository : IRepository<PurchaseOrderHeader>
    {
        private AdventureWorks db;

        public PurchaseOrderHeaderRepository(AdventureWorks context)
        {
            this.db = context;
        }

        public IEnumerable<PurchaseOrderHeader> GetAll()
        {
            return db.PurchaseOrderHeader;
        }

        public PurchaseOrderHeader Get(int id)
        {
            return db.PurchaseOrderHeader.Find(id);
        }

        public void Create(PurchaseOrderHeader poh)
        {
            db.PurchaseOrderHeader.Add(poh);
            db.SaveChanges();
        }

        public void Update(PurchaseOrderHeader poh)
        {
            db.Entry(poh).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            PurchaseOrderHeader poh = db.PurchaseOrderHeader.Find(id);
            if (poh != null)
                db.PurchaseOrderHeader.Remove(poh);
            db.SaveChanges();
        }
    }
}
