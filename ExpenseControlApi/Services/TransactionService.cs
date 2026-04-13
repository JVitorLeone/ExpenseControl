using ExpenseControl.Data.Interfaces;
using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;

namespace ExpenseControl.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public Task<Transaction> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<IEnumerable<Transaction>> GetAllAsync() => _repository.GetAllAsync();

    public Task AddAsync(Transaction transaction) => _repository.AddAsync(transaction);

    public Task UpdateAsync(Transaction transaction) => _repository.UpdateAsync(transaction);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}