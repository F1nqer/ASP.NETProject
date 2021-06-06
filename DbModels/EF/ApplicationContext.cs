using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ASP.NETProject.DbModels.Entities;
using DbModels.Entities;

namespace DbModels.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString)
        {
        }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
