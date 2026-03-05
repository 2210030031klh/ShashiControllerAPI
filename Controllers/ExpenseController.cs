using Microsoft.AspNetCore.Mvc;
using ShashiControllerAPI.Models;
using ShashiControllerAPI.Service;  

namespace ShashiControllerAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ExpenseController (IExpenseService expenseService): ControllerBase
{
    // 1️⃣ Get all expenses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetAllExpensesAsync()
    => await expenseService.GetAllExpensesAsync();

    // 2️⃣ Get expense by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpensesByIdAsync(int id)
    {
        var result = await expenseService.GetExpensesByIdAsync(id);
        return result == null ? NotFound("The expense with the specified ID was not found.") : Ok(result);      
        // if (result == null )
        //     return NotFound("The expense with the specified ID was not found.");

        // return Ok(result);
    }
     // 3️⃣ Get expenses by category
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<Expense>>> GetExpensesByCategoryAsync(string category)
    {
        var result = await expenseService.GetExpensesByCategoryAsync(category);
        return result.Count == 0 ? NotFound($"No expenses found for category '{category}'.") : Ok(result);
    }

    // 4️⃣ Add a new expense
    [HttpPost]
    public async Task<ActionResult<Expense>> AddExpenseAsync([FromBody] Expense expense)
    {
        var added = await expenseService.AddExpenseAsync(expense);
        return Created($"/api/Expense/{added.Id}", added);
    }

    // 5️⃣ Update an existing expense
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateExpenseAsync(int id, [FromBody] Expense expense)
    {
        var updated = await expenseService.UpdateExpenseAsync(id, expense);
        return updated ? NoContent() : NotFound($"Expense with ID {id} not found.");
    }

    // 6️⃣ Delete an expense
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpenseAsync(int id)
    {
        var deleted = await expenseService.DeleteExpenseAsync(id);
        return deleted ? NoContent() : NotFound($"Expense with ID {id} not found.");
    }


}