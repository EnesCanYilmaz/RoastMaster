using System;
using Microsoft.AspNetCore.Identity;

namespace CoffeeProject.Entities.Identity
{
	public class AppRole : IdentityRole
	{
        public AppRole() : base()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {

        }
    }
}

