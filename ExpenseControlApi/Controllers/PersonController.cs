using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetById(int id)
    {
        var person = await _service.GetByIdAsync(id);
        return person is not null ? Ok(person) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Person>> Create(Person person)
    {
        await _service.AddAsync(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Person person)
    {
        if (id != person.Id)
        {
            return BadRequest();
        }

        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(person);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _service.DeleteAsync(id);
        return NoContent();
    }
}