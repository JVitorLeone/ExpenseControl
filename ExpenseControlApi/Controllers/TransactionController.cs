using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionController(ITransactionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Transaction>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Transaction>> GetById(int id)
    {
        var transaction = await _service.GetByIdAsync(id);
        return transaction is not null ? Ok(transaction) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Transaction>> Create(Transaction transaction)
    {
        await _service.AddAsync(transaction);
        return CreatedAtAction(nameof(GetById), new { id = transaction.Id }, transaction);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Transaction transaction)
    {
        if (id != transaction.Id)
        {
            return BadRequest();
        }

        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(transaction);
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