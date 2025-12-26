using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Data;
using MyWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyWebApplicationContext _context;

    public HomeController(ILogger<HomeController> logger, MyWebApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public async Task<IActionResult> AllContacts()
    {
        var users = await _context.User.OrderBy(u => u.Name).ToListAsync();
        return View(users);
    }
    
    // 2. Детали конкретного контакта
    public async Task<IActionResult> ContactDetails(int id)
    {
        // Загружаем пользователя и сразу все его телефон номера
        var user = await _context.User
            .Include(u => u.Phones) 
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) return NotFound();

        return View(user);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}