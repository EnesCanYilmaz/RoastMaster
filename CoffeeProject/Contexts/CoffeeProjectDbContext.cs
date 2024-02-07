using System;
using RoastMaster.Entities;
using RoastMaster.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RoastMaster.Contexts
{
	public class RoastMasterDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public RoastMasterDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }


    }
}