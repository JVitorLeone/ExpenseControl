using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseControl.Models;

public class Transaction
{
    public int Id { get; set; }
    [StringLength(400)]
    public string Description { get; set; }
    [Range(0.01, double.MaxValue)]
    public decimal Value { get; set; }
    public Enums.Type Type { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}