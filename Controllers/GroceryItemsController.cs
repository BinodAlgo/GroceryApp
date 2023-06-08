using GroceryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

public class GroceryItemsController : Controller
{
  private readonly ApplicationDbContext _context;

  public GroceryItemsController(ApplicationDbContext context)
  {
    _context = context;
  }

  // Index action to display a list of grocery items
  [HttpGet]
  public IActionResult Index()
  {
    var groceryItems = _context.GroceryItems.ToList();
    return View(groceryItems);
  }

  [HttpGet]
  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create(GroceryItem groceryItem)
  {
    if (ModelState.IsValid)
    {
      _context.GroceryItems.Add(groceryItem);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(groceryItem);
  }

  [HttpGet]
  public IActionResult Edit(int id)
  {
    var groceryItem = _context.GroceryItems.Find(id);
    if (groceryItem == null)
    {
      return NotFound();
    }
    return View(groceryItem);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(int id, GroceryItem groceryItem)
  {
    if (id != groceryItem.Id)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      _context.Update(groceryItem);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(groceryItem);
  }

  [HttpGet]
  public IActionResult Delete(int id)
  {
    var groceryItem = _context.GroceryItems.Find(id);
    if (groceryItem == null)
    {
      return NotFound();
    }
    return View(groceryItem);
  }

  [HttpPost]
  public async Task<IActionResult> DeleteConfirmed(int id)
  {
    var groceryItem = await _context.GroceryItems.FindAsync(id);
    if (groceryItem == null)
    {
      return NotFound();
    }

    _context.GroceryItems.Remove(groceryItem);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }

}
