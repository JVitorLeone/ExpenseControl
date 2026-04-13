using ExpenseControl.Data.Interfaces;
using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;

namespace ExpenseControl.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public Task<Category> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<IEnumerable<Category>> GetAllAsync() => _repository.GetAllAsync();

    public Task AddAsync(Category category) => _repository.AddAsync(category);

    public Task UpdateAsync(Category category) => _repository.UpdateAsync(category);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}