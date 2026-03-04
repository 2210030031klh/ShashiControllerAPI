using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public interface IExpenseService
{
    Task<List<Expense>> GetAllExpensesAsync();

    Task<Expense?> GetExpensesByIdAsync(int id);

    Task<List<Expense>> GetExpensesByCategoryAsync(string category);

    Task<Expense> AddExpenseAsync(Expense expense);

    Task<bool> UpdateExpenseAsync(int id, Expense expense);

    Task<bool> DeleteExpenseAsync(int id);


}