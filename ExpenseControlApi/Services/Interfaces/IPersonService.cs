using ExpenseControl.Models;

namespace ExpenseControl.Services.Interfaces;

public interface IPersonService
{
    Task<Person> GetByIdAsync(int id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(int id);
}