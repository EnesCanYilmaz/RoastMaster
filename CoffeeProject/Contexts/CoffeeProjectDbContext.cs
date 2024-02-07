using System;
using CoffeeProject.Entities;
using CoffeeProject.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeeProject.Contexts
{
	public class CoffeeProjectDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public CoffeeProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }


    }
}