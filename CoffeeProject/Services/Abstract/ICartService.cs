﻿using RoastMaster.Entities;

namespace RoastMaster.Services
{
    public interface ICartService
    {
        void RemoveFromCart(Cart cart, int coffeeId);
        List<CartLine> List(Cart cart);
        public void AddToCart(Cart cart, Coffee coffee);
    }
}

