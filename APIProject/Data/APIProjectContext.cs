using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseProvider;
using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace APIProject.Data
{
  public class APIProjectContext : IdentityDbContext<IdentityUser>
  {
    public APIProjectContext(DbContextOptions<APIProjectContext> options)
        : base(options)
    {
    }

    // admin model
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

    // staff model
    public DbSet<cus_info> cus_info { get; set; }

    public DbSet<booked_cus_info> booked_cus_info { get; set; }
    
    public DbSet<booked_room_info> booked_room_info { get; set; }
    
    public DbSet<emp_info> emp_info { get; set; }
    
    public DbSet<room_booking> room_booking { get; set; }
    
    public DbSet<room_info> room_info { get; set; }
    
    public DbSet<room_status_info> room_status_info { get; set; }
    protected override void OnModelCreating (ModelBuilder builder)
    {
      builder.Entity<booked_cus_info>()
        .HasNoKey();
      builder.Entity<booked_room_info>()
        .HasNoKey();
      builder.Entity<cus_info>()
        .HasNoKey();
      builder.Entity<emp_info>()
        .HasNoKey();
      builder.Entity<room_booking>()
        .HasNoKey();
      builder.Entity<room_info>()
        .HasNoKey();
      builder.Entity<room_status_info>()
        .HasNoKey();

      base.OnModelCreating(builder);
    }
  }
}