using System;
using RoastMaster.Entities.Identity;

namespace RoastMaster.Models
{
    public class CreatePaymentCardModel
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string SecurityCode { get; set; }
        public string CardName { get; set; }

    }
}

