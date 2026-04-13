using ExpenseControl.Models;

namespace ExpenseControl.Services.Interfaces;

public interface ICategoryService
{
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}