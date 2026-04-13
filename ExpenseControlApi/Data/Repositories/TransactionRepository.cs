using ExpenseControl.Data.Interfaces;
using ExpenseControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ExpenseControlDbContext _context;

    public TransactionRepository(ExpenseControlDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction> GetByIdAsync(int id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var transaction = await GetByIdAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}