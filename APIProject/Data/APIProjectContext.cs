using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseProvider;

namespace APIProject.Data
{
    public class APIProjectContext : DbContext
    {
        public APIProjectContext (DbContextOptions<APIProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DatabaseProvider.employee> employee { get; set; }

        public DbSet<DatabaseProvider.account> account { get; set; }

        public DbSet<DatabaseProvider.customer> customer { get; set; }

        public DbSet<DatabaseProvider.payment> payment { get; set; }

        public DbSet<DatabaseProvider.paymentType> paymentType { get; set; }
    }
}
