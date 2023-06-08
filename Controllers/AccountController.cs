using Microsoft.AspNetCore.Mvc;
using GroceryManagementSystem.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

public class AccountController : Controller
{
  private readonly ApplicationDbContext _context;

  public AccountController(ApplicationDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(User user)
  {
    var account = _context.Users.FirstOrDefault(u => u.Username == user.Username);

    // Check if account exists
    if (account != null)
    {
      // Check if password is correct
      if (account.CheckPassword(user.Password))
      {
        // Create claims for authentication
        var claims = new[]
        {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, account.UserRole)
                };

        // Create identity from claims
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        // Sign in user
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        // Redirect to appropriate dashboard based on role
        if (account.UserRole == "Admin")
        {
          return RedirectToAction("Index", "Admin");
        }
        else if (account.UserRole == "Employee")
        {
          return RedirectToAction("Index", "Home");
        }
      }
    }

    // Invalid username or password
    ModelState.AddModelError("", "Invalid username or password.");
    return View();
  }

  [HttpGet]
  public IActionResult Register()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Register(User user)
  {
    if (!ModelState.IsValid)
    {
      // If the model is invalid, return the form with error messages.
      return View(user);
    }

    user.HashPassword();

    _context.Users.Add(user);
    _context.SaveChanges();

    return RedirectToAction("Login");
  }

  public async Task<IActionResult> Logout()
  {
    // Perform the logout process
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    // Redirect to the home page or any other page after logout
    return RedirectToAction("Index", "Home");
  }

  public IActionResult AccessDenied(string returnUrl)
  {
    // Handle access denied scenarios
    return View();
  }
}
