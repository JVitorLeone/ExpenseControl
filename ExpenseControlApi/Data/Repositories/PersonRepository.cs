using ExpenseControl.Data.Interfaces;
using ExpenseControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControl.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ExpenseControlDbContext _context;

    public PersonRepository(ExpenseControlDbContext context)
    {
        _context = context;
    }

    public async Task<Person> GetByIdAsync(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task AddAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Person person)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var person = await GetByIdAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}