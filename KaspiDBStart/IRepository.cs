using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaspiDBStart
{
    interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        //maybe Get(), but CRUD with READ
        IEnumerable<TEntity> Read();
        IEnumerable<TEntity> Read(Func<TEntity, bool> predicate);
        void Delete(TEntity item);
        void Update(TEntity item);
    }
}
