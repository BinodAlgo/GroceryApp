using System.Security.Claims;
using GroceryManagementSystem.Data;
using GroceryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  private readonly ApplicationDbContext _context;

  public HomeController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    var groceryItems = _context.GroceryItems.ToList();
    return View(groceryItems);
  }

  public IActionResult Details(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var groceryItem = _context.GroceryItems.FirstOrDefault(item => item.Id == id);
    if (groceryItem == null)
    {
      return NotFound();
    }

    return View(groceryItem);
  }
  public IActionResult AddToCart(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var groceryItem = _context.GroceryItems.FirstOrDefault(item => item.Id == id);
    if (groceryItem == null)
    {
      return NotFound();
    }

    // Get the currently logged-in user ID
    var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

    // Check if the user with the specified ID exists
    var user = _context.Users.FirstOrDefault(u => u.Id == userId);
    if (user == null)
    {
      return NotFound();
    }

    // Create a new bill entry with the selected grocery item
    var bill = new Bill
    {
      Date = DateTime.Now,
      UserId = userId,
      GroceryItemId = groceryItem.Id,
      Quantity = 1,
      IsPaid = false
    };

    _context.Bills.Add(bill);
    _context.SaveChanges();

    return RedirectToAction("Index", "Bills");
  }


}
