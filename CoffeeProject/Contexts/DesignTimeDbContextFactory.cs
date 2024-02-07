using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoffeeProject.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoffeeProjectDbContext>
    {
        public CoffeeProjectDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CoffeeProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

