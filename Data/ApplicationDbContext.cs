using GroceryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagementSystem.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<GroceryItem> GroceryItems { get; set; }
  }

}
