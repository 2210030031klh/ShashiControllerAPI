using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public interface IExpenseService
{
    Task<List<GetExpenseDto>> GetAllExpensesAsync(Guid userId);

    Task<GetExpenseDto?> GetExpensesByIdAsync(Guid id);

    Task<List<GetExpenseDto>> GetExpensesByCategoryAsync(string category);

    Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto expense, Guid userId);

    Task<bool> UpdateExpenseAsync(Guid id, UpdateExpenseDto  expense);

    Task<bool> DeleteExpenseAsync(Guid id);

    Task<List<GetExpenseDto>> GetExpensesByDateRangeAsync(Guid userId, DateOnly startDate, DateOnly endDate);

    Task<List<MonthlyReportDto>> GetMonthlyReportAsync(Guid userId);

    Task<List<CategoryReportDto>> GetCategoryReportAsync(Guid userId);

    Task<List<GetExpenseDto>> GetAllUsersExpensesAsync();


}