using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RoastMaster.Entities.Identity;

namespace RoastMaster.Entities
{
    public class PaymentCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string SecurityCode { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}

