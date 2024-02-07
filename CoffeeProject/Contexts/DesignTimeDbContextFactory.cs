using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RoastMaster.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RoastMasterDbContext>
    {
        public RoastMasterDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RoastMasterDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}

