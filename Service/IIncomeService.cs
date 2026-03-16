using ShashiControllerAPI.DTOs;

namespace ShashiControllerAPI.Service;

public interface IIncomeService
{
    Task<List<GetIncomeDto>> GetAllIncomesAsync(Guid userId);
    Task<GetIncomeDto?> GetIncomeByIdAsync(Guid id, Guid userId);
    Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto income, Guid userId);
    Task<bool> UpdateIncomeAsync(Guid id, UpdateIncomeDto income, Guid userId);
    Task<bool> DeleteIncomeAsync(Guid id, Guid userId);
}