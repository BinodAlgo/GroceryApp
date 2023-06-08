using System.ComponentModel.DataAnnotations;

public class Employee
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public string? Position { get; set; }
}
