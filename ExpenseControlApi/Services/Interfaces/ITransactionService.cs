using ExpenseControl.Models;

namespace ExpenseControl.Services.Interfaces;

public interface ITransactionService
{
    Task<Transaction> GetByIdAsync(int id);
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(int id);
}