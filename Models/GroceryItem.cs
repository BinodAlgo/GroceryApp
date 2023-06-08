using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroceryManagementSystem.Models;

public class GroceryItem
{
  [Key]
  public int Id { get; set; }
  [ForeignKey("Bill")]
  public int? BillId { get; set; }

  public virtual Bill? Bill { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public decimal Price { get; set; }

  public string? Description {get;set;}

 [Required]
 public int Quantity {get;set;}
public string? ImageUrl { get; set; }
}
