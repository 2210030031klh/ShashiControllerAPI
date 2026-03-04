using Microsoft.AspNetCore.Mvc;
using ShashiControllerAPI.Models;
using ShashiControllerAPI.Service;  

namespace ShashiControllerAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ExpenseController (IExpenseService expenseService): ControllerBase
{
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetAllExpensesAsync()
    => await expenseService.GetAllExpensesAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpensesByIdAsync(int id)
    {
        var result = await expenseService.GetExpensesByIdAsync(id);
        return result == null ? NotFound("The expense with the specified ID was not found.") : Ok(result);      
        // if (result == null )
        //     return NotFound("The expense with the specified ID was not found.");

        // return Ok(result);
    }


}