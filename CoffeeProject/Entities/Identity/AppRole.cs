using System;
using Microsoft.AspNetCore.Identity;

namespace RoastMaster.Entities.Identity
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

