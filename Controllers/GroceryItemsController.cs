using GroceryManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;


public class GroceryItemsController : Controller
{
  private readonly ApplicationDbContext _context;
  private readonly IWebHostEnvironment _webHostEnvironment;

  public GroceryItemsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
  {
    _context = context;
    _webHostEnvironment = webHostEnvironment;
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
  public async Task<IActionResult> Create(GroceryItem groceryItem, IFormFile imageFile)
  {
    if (ModelState.IsValid)
    {
      // Save the image file
      if (imageFile != null && imageFile.Length > 0)
      {
        var uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsDir))
        {
          Directory.CreateDirectory(uploadsDir);
        }

        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsDir, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
          await imageFile.CopyToAsync(fileStream);
        }

        // Assign the file path to the GroceryItem's ImageUrl property
        groceryItem.ImageUrl = "/uploads/" + fileName;
      }

      _context.GroceryItems.Add(groceryItem);
      await _context.SaveChangesAsync(); // Save changes asynchronously
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
  public async Task<IActionResult> Edit(int id, GroceryItem groceryItem, IFormFile imageFile)
  {
    if (id != groceryItem.Id)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      // Save the image file
      if (imageFile != null && imageFile.Length > 0)
      {
        var uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        if (!Directory.Exists(uploadsDir))
        {
          Directory.CreateDirectory(uploadsDir);
        }

        var fileName = Path.GetRandomFileName() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsDir, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
          await imageFile.CopyToAsync(fileStream);
        }

        // Assign the file path to the GroceryItem's ImageUrl property
        groceryItem.ImageUrl = "/uploads/" + fileName;
      }

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

    // Delete the associated image file
    if (!string.IsNullOrEmpty(groceryItem.ImageUrl))
    {
      var filePath = Path.Combine(_webHostEnvironment.WebRootPath, groceryItem.ImageUrl.TrimStart('/'));
      if (System.IO.File.Exists(filePath))
      {
        System.IO.File.Delete(filePath);
      }
    }

    _context.GroceryItems.Remove(groceryItem);
    await _context.SaveChangesAsync();

    return RedirectToAction(nameof(Index));
  }
}
