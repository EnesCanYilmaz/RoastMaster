using System;
using RoastMaster.Entities;

namespace RoastMaster.Services
{
	public class CartSessionService : ICartSessionService
	{
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<Cart>("cart");
            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObjectAsJson("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<Cart>("cart");
            }

            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson("cart", cart);
        }
    }
}

