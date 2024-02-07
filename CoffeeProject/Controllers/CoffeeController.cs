using System.Linq;
using System.Threading.Tasks;
using CoffeeProject.Contexts;
using CoffeeProject.Entities;
using CoffeeProject.Models; // Coffee model sınıfının doğru namespace'e sahip olduğundan emin olun
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class CoffeeController : Controller
{
    private readonly CoffeeProjectDbContext _dbContext;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public CoffeeController(CoffeeProjectDbContext dbContext, IWebHostEnvironment webHostEnvironment)
    {
        _dbContext = dbContext;
        _webHostEnvironment = webHostEnvironment;
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCoffeeModel coffee) // CoffeeModel tipini kullanın
    {
        if (ModelState.IsValid)
        {
            
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "coffee-photo");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var fullFilePath = Path.Combine(filePath, coffee.Photo.FileName);

            using(var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                await coffee.Photo.CopyToAsync(fileStream);
            }

            var coffeeEntity = new Coffee // Coffee modelinden yeni bir Coffee entity'si oluşturun
            {
                Id = coffee.Id,
                Name = coffee.Name,
                Description = coffee.Description,
                Price = coffee.Price,
                PhotoPath = coffee.Photo.FileName
            };

            _dbContext.Coffees.Add(coffeeEntity);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(coffee);
    }

    public async Task<IActionResult> Index()
    {
        var coffeeEntities = await _dbContext.Coffees.ToListAsync();
        var coffeeModels = coffeeEntities.Select(c => new CoffeeModel // Coffee entity'lerini CoffeeModel'lere dönüştürün
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            Price = c.Price
        }).ToList();

        return View(coffeeModels);
    }

    public IActionResult Edit(int id)
    {
        var coffeeEntity = _dbContext.Coffees.Find(id); // ID'ye göre Coffee entity'sini bulun

        if (coffeeEntity == null)
        {
            return NotFound(); // Eğer Coffee entity'si bulunamazsa, 404 Not Found döndürün veya başka bir işlem yapın
        }

        var coffeeModel = new CoffeeModel
        {
            Id = coffeeEntity.Id,
            Name = coffeeEntity.Name,
            Description = coffeeEntity.Description,
            Price = coffeeEntity.Price
        };

        return View(coffeeModel);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(CoffeeModel coffee) // CoffeeModel tipini kullanın
    {
        if (ModelState.IsValid)
        {
            var coffeeEntity = await _dbContext.Coffees.FindAsync(coffee.Id); // Id'ye göre Coffee entity'sini bulun

            if (coffeeEntity != null)
            {
                coffeeEntity.Name = coffee.Name;
                coffeeEntity.Description = coffee.Description;
                coffeeEntity.Price = coffee.Price;

                _dbContext.Entry(coffeeEntity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        return View(coffee);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(CoffeeDeleteModel model)
    {
        var coffee = await _dbContext.Coffees.FindAsync(model.Id);
        if (coffee != null)
        {
            _dbContext.Coffees.Remove(coffee);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}
