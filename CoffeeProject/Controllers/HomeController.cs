using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoffeeProject.Models;
using Microsoft.EntityFrameworkCore;
using CoffeeProject.Contexts;
using CoffeeProject.Services;
using System.ComponentModel;

namespace CoffeeProject.Controllers;

public class HomeController : Controller
{
    private readonly CoffeeProjectDbContext _dbContext;
    private readonly ICartSessionService _cartSessionService;
    public HomeController(CoffeeProjectDbContext dbContext, ICartSessionService cartSessionService)
    {
        _dbContext = dbContext;
        _cartSessionService = cartSessionService;
    }

    public async Task<IActionResult> Index()
    {
        if (HttpContext.Session != null)
        {
            string fullName = HttpContext.Session.GetString("FullName");
            if (fullName != null)
            {
                ViewData["FullName"] = fullName;
            }
            else
            {
                ViewData["FullName"] = null;
            }
        }
        else
        {
            ViewData["FullName"] = null;
        }
        var coffeeEntities = await _dbContext.Coffees.ToListAsync();
        var coffeeModels = coffeeEntities.Select(c => new CoffeeModel 
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Price = c.Price,
            PhotoPath = c.PhotoPath
        }).ToList();
        return View(coffeeModels);
    }
}

