using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoastMaster.Models;
using Microsoft.EntityFrameworkCore;
using RoastMaster.Contexts;
using RoastMaster.Services;
using System.ComponentModel;

namespace RoastMaster.Controllers;

public class HomeController : Controller
{
    private readonly RoastMasterDbContext _dbContext;
    private readonly ICartSessionService _cartSessionService;
    public HomeController(RoastMasterDbContext dbContext, ICartSessionService cartSessionService)
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

