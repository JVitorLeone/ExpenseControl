using ExpenseControl.Models;
using ExpenseControl.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);
        return category is not null ? Ok(category) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        await _service.AddAsync(category);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest();
        }

        var existing = await _service.GetByIdAsync(id);
        if (existing is null)
        {
            return NotFound();
        }

        await _service.UpdateAsync(category);
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