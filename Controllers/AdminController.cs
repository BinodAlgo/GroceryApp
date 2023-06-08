using GroceryManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Policy = "AdminOnly")]
public class AdminController : Controller
{
  private readonly ApplicationDbContext _context;

  public AdminController(ApplicationDbContext context)
  {
    _context = context;
  }


  public async Task<IActionResult> Index(string searchString)
  {
    var users = await _context.Users.ToListAsync();

    if (!string.IsNullOrEmpty(searchString))
    {
      users = users.Where(user =>
          user.Username.Contains(searchString, StringComparison.OrdinalIgnoreCase))
          .ToList();
    }

    return View(users);
  }



  public IActionResult CreateUser()
  {
    return View();
  }

  [HttpPost]
  public IActionResult CreateUser(User user)
  {
    if (ModelState.IsValid)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(user);
  }

  public IActionResult EditUser(int id)
  {
    var user = _context.Users.Find(id);
    if (user == null)
    {
      return NotFound();
    }
    return View(user);
  }

  [HttpPost]
  public IActionResult EditUser(User user)
  {
    if (ModelState.IsValid)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
      return RedirectToAction(nameof(Index));
    }
    return View(user);
  }

  public IActionResult DeleteUser(int id)
  {
    var user = _context.Users.Find(id);
    if (user == null)
    {
      return NotFound();
    }
    return View(user);
  }

  // ...

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteUserConfirmed(int id)
  {
    var user = _context.Users.Find(id);
    if (user == null)
    {
      return NotFound();
    }

    _context.Users.Remove(user);
    _context.SaveChanges();

    return RedirectToAction(nameof(Index));
  }

}
