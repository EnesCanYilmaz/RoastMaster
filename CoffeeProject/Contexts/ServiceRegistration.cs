﻿using System;
using RoastMaster.Entities.Identity;
using RoastMaster.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoastMaster.Contexts;

namespace RoastMaster.Contexts
{

    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<RoastMasterDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartSessionService, CartSessionService>();

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<RoastMasterDbContext>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();

                var roles = new string[] { "Admin", "Editor", "User" };
                foreach (var roleName in roles)
                {
                    if (!roleManager.RoleExistsAsync(roleName).Result)
                    {
                        var role = new AppRole { Name = roleName };
                        roleManager.CreateAsync(role).Wait();
                    }
                }
            }

        }
    }
}

