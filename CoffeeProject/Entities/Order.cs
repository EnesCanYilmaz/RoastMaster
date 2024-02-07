using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeProject.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace CoffeeProject.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Coffee Coffee { get; set; }
        public AppUser AppUser { get; set; }
    }

}

