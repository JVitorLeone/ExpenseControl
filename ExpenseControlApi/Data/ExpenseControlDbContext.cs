using ExpenseControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Data;

public class ExpenseControlDbContext : DbContext
{
    public ExpenseControlDbContext(DbContextOptions<ExpenseControlDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}