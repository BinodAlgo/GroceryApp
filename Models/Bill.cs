using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryManagementSystem.Models
{
  public class Bill
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [ForeignKey("User")]
    public int UserId { get; set; }

    [Required]
    [ForeignKey("GroceryItem")]
    public int GroceryItemId { get; set; }

    [Required]
    public int Quantity { get; set; }

    public virtual User User { get; set; }
    public virtual GroceryItem GroceryItem { get; set; }

    public bool IsPaid { get; set; }

    [NotMapped]
    public decimal GrandTotal
    {
      get
      {
        return GroceryItem?.Price * Quantity ?? 0;
      }
    }
  }
}
