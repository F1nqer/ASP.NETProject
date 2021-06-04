using DbModels.ContextModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class TerritoryRepository : IRepository<SalesTerritory>
    {
        private AdventureWorks db;

        public TerritoryRepository(AdventureWorks context)
        {
            this.db = context;
        }

        public IEnumerable<SalesTerritory> GetAll()
        {
            return db.SalesTerritory;
        }

        public SalesTerritory Get(int id)
        {
            return db.SalesTerritory.Find(id);
        }

        public void Create(SalesTerritory st)
        {
            db.SalesTerritory.Add(st);
            db.SaveChanges();
        }

        public void Update(SalesTerritory st)
        {
            db.Entry(st).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            SalesTerritory st = db.SalesTerritory.Find(id);
            if (st != null)
                db.SalesTerritory.Remove(st);
            db.SaveChanges();
        }
    }
}
