using ShashiControllerAPI.DTOs;

namespace ShashiControllerAPI.Service;

public interface IBudgetService
{
    Task<List<GetBudgetDto>> GetAllBudgetsAsync(Guid userId);
    Task<CreateBudgetDto> AddBudgetAsync(CreateBudgetDto budget, Guid userId);
    Task<bool> UpdateBudgetAsync(Guid id, CreateBudgetDto budget);
    Task<bool> DeleteBudgetAsync(Guid id);
    Task<List<BudgetReportDto>> GetBudgetReportAsync(Guid userId, int month, int year);
}