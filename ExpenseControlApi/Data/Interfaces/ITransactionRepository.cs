using ExpenseControl.Models;

namespace ExpenseControl.Data.Interfaces;

public interface ITransactionRepository
{
    Task<Transaction> GetByIdAsync(int id);
    Task<IEnumerable<Transaction>> GetAllAsync();
    Task AddAsync(Transaction transaction);
    Task UpdateAsync(Transaction transaction);
    Task DeleteAsync(int id);
}