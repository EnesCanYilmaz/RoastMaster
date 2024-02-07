using System;
using Microsoft.AspNetCore.Identity;

namespace RoastMaster.Entities.Identity
{
	public class AppUser : IdentityUser<string>
	{
        public string FullName { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PaymentCard> PaymentCards { get; set; }
    }
}

