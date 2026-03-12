using ShashiControllerAPI.DTOs;

namespace ShashiControllerAPI.Service;

public interface IIncomeService
{
    Task<List<GetIncomeDto>> GetAllIncomesAsync(Guid userId);
    Task<GetIncomeDto?> GetIncomeByIdAsync(Guid id);
    Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto income, Guid userId);
    Task<bool> UpdateIncomeAsync(Guid id, UpdateIncomeDto income);
    Task<bool> DeleteIncomeAsync(Guid id);
}