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

        public DbSet<employee> employee { get; set; }

        public DbSet<account> account { get; set; }

        public DbSet<customer> customer { get; set; }

        public DbSet<payment> payment { get; set; }

        public DbSet<paymentType> paymentType { get; set; }

        public DbSet<role> role { get; set; }

        public DbSet<DatabaseProvider.reception> reception { get; set; }

        public DbSet<DatabaseProvider.reservation> reservation { get; set; }

        public DbSet<DatabaseProvider.room> room { get; set; }

        public DbSet<DatabaseProvider.roomStatu> roomStatu { get; set; }

        public DbSet<DatabaseProvider.roomType> roomType { get; set; }
    }
}
