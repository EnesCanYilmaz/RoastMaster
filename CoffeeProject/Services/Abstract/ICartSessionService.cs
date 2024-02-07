using System;
using RoastMaster.Entities;

namespace RoastMaster.Services
{
	public interface ICartSessionService
	{
        Cart GetCart();
        void SetCart(Cart cart);
    }
}

