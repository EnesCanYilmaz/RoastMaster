using System;
using RoastMaster.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace RoastMaster.Services
{
    public class CartService : ICartService
    {
        public void AddToCart(Cart cart, Coffee coffee)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Coffee.Id == coffee.Id);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            cart.CartLines.Add(new CartLine { Coffee = coffee, Quantity = 1 });
        }

        public void RemoveFromCart(Cart cart, int coffeeId)
        {
            var cartItem = cart.CartLines.FirstOrDefault(item => item.Coffee.Id == coffeeId);
            if (cartItem != null)
            {
                cart.CartLines.Remove(cartItem);
            }
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }
    }
}

