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

        public DbSet<reception> reception { get; set; }

        public DbSet<reservation> reservation { get; set; }

        public DbSet<room> room { get; set; }

        public DbSet<roomStatus> roomStatus { get; set; }

        public DbSet<roomType> roomType { get; set; }
        //public DbSet<empInfo> empInfo { get; set; }
    }
}
