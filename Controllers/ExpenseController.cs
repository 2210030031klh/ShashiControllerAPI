using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;
using ShashiControllerAPI.Service;

namespace ShashiControllerAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ExpenseController (IExpenseService expenseService): ControllerBase
{
    // 1️⃣ Get all expenses
    [HttpGet]
    public async Task<ActionResult<List<GetExpenseDto>>> GetAllExpenses()
    => Ok(await expenseService.GetAllExpensesAsync());

    // 2️⃣ Get expense by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<GetExpenseDto>> GetExpensesById(Guid id, Guid userId)
    {
        var result = await expenseService.GetExpensesByIdAsync(id, userId);
        return result is null ? NotFound("The expense with the specified ID was not found.") : Ok(result);      
        // if (result == null )
        //     return NotFound("The expense with the specified ID was not found.");

        // return Ok(result);
    }
     // 3️⃣ Get expenses by category
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<GetExpenseDto>>> GetExpensesByCategory(string category)
    {
        var result = await expenseService.GetExpensesByCategoryAsync(category);
        return result.Count is 0 ? NotFound($"No expenses found for category '{category}'.") : Ok(result);
    }

    // 4️⃣ Add a new expense
    [HttpPost]
    public async Task<ActionResult<Expense>> AddExpense(CreateExpenseDto expense)
    {
        // var added = await expenseService.AddExpenseAsync(expense); 
        // return CreatedAtAction(nameof(AddExpense), new { id = added.Id }, added);
        if (expense.Amount <= 0)
            return BadRequest("Amount must be greater than 0.");
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        try{
            var added = await expenseService.AddExpenseAsync(expense, userId);
            return Ok(added);
        }
        catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // 5️⃣ Update an existing expense
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateExpenseAsync(Guid id,  UpdateExpenseDto expense)
    {
        var updated = await expenseService.UpdateExpenseAsync(id, expense);
        return updated ? NoContent() : NotFound($"Expense with ID {id} not found.");
    }

    // 6️⃣ Delete an expense
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpenseAsync(Guid id)
    {
        var deleted = await expenseService.DeleteExpenseAsync(id);
        return deleted ? NoContent() : NotFound($"Expense with ID {id} not found.");
    }

    [HttpGet("ByDateRange")]
    [Authorize]
    public async Task<ActionResult<List<GetExpenseDto>>> GetExpensesByDateRange
    (
        [FromQuery] DateOnly startDate, 
        [FromQuery] DateOnly endDate)
    {
        if (startDate > endDate)
            return BadRequest("Start date cannot be greater than end date.");
        
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await expenseService.GetExpensesByDateRangeAsync(userId, startDate, endDate);
        return result.Count is 0 ? NotFound("No expenses found for this date range.") : Ok(result);
    }
    [HttpGet("report/monthly")]
    [Authorize]
    public async Task<ActionResult<List<MonthlyReportDto>>> GetMonthlyReport()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await expenseService.GetMonthlyReportAsync(userId);
        return result.Count is 0 ? NotFound("No data found.") : Ok(result);
    }

    [HttpGet("report/category")]
    [Authorize]
    public async Task<ActionResult<List<CategoryReportDto>>> GetCategoryReport()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await expenseService.GetCategoryReportAsync(userId);
        return result.Count is 0 ? NotFound("No data found.") : Ok(result);
    }

  [HttpGet("all")]
[Authorize(Roles = "Accountant")]
public async Task<ActionResult<List<GetExpenseDto>>> GetAllUsersExpenses()
{
    var result = await expenseService.GetAllUsersExpensesAsync();
    return result.Count is 0 ? NotFound("No expenses found.") : Ok(result);
}


}