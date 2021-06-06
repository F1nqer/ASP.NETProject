using DbModels.ContextModels;
using BusinessLogics;
using DbModels.EF;
using DbModels.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class ClientManagerRepository : IClientManager
    {
        public ApplicationContext Database = new ApplicationContext("Identity");
        public ClientManagerRepository()
        {
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            try
            {
                Database.SaveChanges();
            }
            catch 
            {
                Database.SaveChanges();
            }
        }

        public List<ClientProfile> GetAll()
        {
            return Database.ClientProfiles.ToList();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
