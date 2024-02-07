using System;
namespace CoffeeProject.Models
{
	public class PaymentCardListModel
	{
        public string? CardName { get; internal set; }
        public string? ExpiryDate { get; set; }
        public string? CardNumber { get; set; }
    }
}

