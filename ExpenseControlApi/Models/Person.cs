using System.ComponentModel.DataAnnotations;

namespace ExpenseControl.Models
{
  public class Person
  {
    public int Id { get; set; }
    [StringLength(200)]
    public string Name { get; set; }
    public int Age { get; set; }
  }
}