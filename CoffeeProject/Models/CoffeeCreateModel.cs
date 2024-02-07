﻿using System;
using CoffeeProject.Entities;

namespace CoffeeProject.Models
{
    public class CreateCoffeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}

