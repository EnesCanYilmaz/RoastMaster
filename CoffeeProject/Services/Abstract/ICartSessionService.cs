using System;
using CoffeeProject.Entities;

namespace CoffeeProject.Services
{
	public interface ICartSessionService
	{
        Cart GetCart();
        void SetCart(Cart cart);
    }
}

