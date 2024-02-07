using System;
using System.ComponentModel.DataAnnotations;

namespace RoastMaster.Models
{
	public class LoginViewModel
	{
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

