using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Contexts;
using CoffeeProject.Entities;
using CoffeeProject.Models;
using CoffeeProject.Services;
using Microsoft.AspNetCore.Mvc;


namespace CoffeeProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartSessionService _cartSessionService;
        private readonly ICartService _cartService;
        private readonly CoffeeProjectDbContext _dbContext;

        public CartController(ICartSessionService cartSessionService, ICartService cartService, CoffeeProjectDbContext dbContext)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _dbContext = dbContext;
        }

        public ActionResult AddToCart(int coffeeId)
        {
            var coffeeToBeAdded = _dbContext.Coffees.FirstOrDefault(c => c.Id == coffeeId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, coffeeToBeAdded);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your product, {0}, was successfully added to the cart!", coffeeToBeAdded.Name));

            return RedirectToAction("Index", "Home");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
        public ActionResult Remove(int coffeeId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, coffeeId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", String.Format("Your product was successfully removed from the cart!"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            return View();
        }
    }
}

