using ExpenseControl.Data.Interfaces;
using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;

namespace ExpenseControl.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public Task<Person> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<IEnumerable<Person>> GetAllAsync() => _repository.GetAllAsync();

    public Task AddAsync(Person person) => _repository.AddAsync(person);

    public Task UpdateAsync(Person person) => _repository.UpdateAsync(person);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}