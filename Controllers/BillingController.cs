using System.Security.Claims;
using GroceryManagementSystem.Data;
using GroceryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BillingController : Controller
{
  private readonly ApplicationDbContext _context;

  public BillingController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    var bills = _context.Bills.Include(b => b.GroceryItem).ToList();
    return View(bills);
  }

  public IActionResult Create()
  {
    var groceryItems = _context.GroceryItems.ToList();
    return View(groceryItems);
  }

  [HttpPost]
  public IActionResult Create(int groceryItemId, int quantity)
  {
    if (ModelState.IsValid)
    {
      var groceryItem = _context.GroceryItems.FirstOrDefault(item => item.Id == groceryItemId);
      if (groceryItem == null)
      {
        ModelState.AddModelError("", "Invalid grocery item selected.");
        var items = _context.GroceryItems.ToList();
        return View(items);
      }

      // Get the currently logged-in user ID
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

      var bill = new Bill
      {
        Date = DateTime.Now,
        UserId = Convert.ToInt32(userId),
        GroceryItemId = groceryItemId,
        Quantity = quantity,
        IsPaid = false
      };

      _context.Bills.Add(bill);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    var groceryItemsList = _context.GroceryItems.ToList();
    return View(groceryItemsList);
  }
}
