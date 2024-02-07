using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeProject.Models
{
	public class LoginViewModel
	{
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

