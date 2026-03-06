using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public interface IExpenseService
{
    Task<List<GetExpenseDto>> GetAllExpensesAsync();

    Task<GetExpenseDto?> GetExpensesByIdAsync(int id);

    Task<List<GetExpenseDto>> GetExpensesByCategoryAsync(string category);

    Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto expense);

    Task<bool> UpdateExpenseAsync(int id, UpdateExpenseDto  expense);

    Task<bool> DeleteExpenseAsync(int id);


}