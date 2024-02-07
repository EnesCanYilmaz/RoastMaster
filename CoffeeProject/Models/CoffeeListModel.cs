using System;
using RoastMaster.Entities;

namespace RoastMaster.Models
{
    public class CoffeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }


        public static CoffeeModel FromCoffeeEntity(Coffee coffeeEntity)
        {
            return new CoffeeModel
            {
                Id = coffeeEntity.Id,
                Name = coffeeEntity.Name,
                Description = coffeeEntity.Description,
                Price = coffeeEntity.Price,
                Photo = coffeeEntity.Photo,
                PhotoPath = coffeeEntity.PhotoPath
            };
        }
    }

}

