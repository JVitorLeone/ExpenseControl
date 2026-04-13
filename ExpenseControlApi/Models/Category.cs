using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.Models;

public class Category
{
    public int Id { get; set; }
    [StringLength(400)]
    public string Description { get; set; }
    public Enums.Purpose Purpose { get; set; }
}