namespace ShashiControllerAPI.Service;
using Microsoft.EntityFrameworkCore;
using ShashiControllerAPI.Data;
using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

public class ExpenseService (AppDbContext context): IExpenseService
{
    //check if which user is logged in and then return the expenses of that user only
    public async Task<List<GetExpenseDto>> GetAllExpensesAsync(Guid userId)
    => await context.Expenses
        .Where(e => e.UserId == userId)
        .Include(e => e.Category)
        .Select(e => new GetExpenseDto
            {
                ExpenseId = e.ExpenseId,

                UserId = e.UserId,
                Name= e.Name,
                CategoryName = e.Category.CategoryName,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                CreatedAt = e.CreatedAt
            }).ToListAsync();

    
    //didnt use userid , need to use it to filter the expenses of that user only
    public async Task<List<GetExpenseDto>> GetExpensesByCategoryAsync(string category, Guid userId)
    {
        return await context.Expenses
            .Include(e => e.Category)
            .Where(e => e.UserId == userId && e.Category.CategoryName.ToLower() == category.ToLower())
            .Select(e => new GetExpenseDto
            {
                ExpenseId = e.ExpenseId,
                UserId = e.UserId,
                Name = e.Name,
                CategoryName = e.Category.CategoryName,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                CreatedAt = e.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto expense, Guid UserId)
    {
        var userExists = await context.Users.AnyAsync(u => u.UserId == UserId);
        if (!userExists)
        throw new ArgumentException("User not found.");

        var categoryExists = await context.Categories.AnyAsync(c => c.CategoryId == expense.CategoryId);
        if (!categoryExists)
                throw new ArgumentException("Category does not exist.");


        if (expense.Amount <= 0)
            throw new ArgumentException("Amount must be greater than 0.");
        var newExpense = new Expense
        {
            UserId = UserId,
            Name= expense.Name,
            CategoryId = expense.CategoryId,
            Amount = expense.Amount,
            Description = expense.Description,
            Date = expense.Date
        };

        context.Expenses.Add(newExpense);
        await context.SaveChangesAsync();

        return new CreateExpenseDto
        {
            // UserId = newExpense.UserId,
            CategoryId = newExpense.CategoryId,
            Name = newExpense.Name,
            Amount = newExpense.Amount,
            Description = newExpense.Description,
            Date = newExpense.Date
        };
    }

    public async Task<bool> UpdateExpenseAsync(Guid  id, UpdateExpenseDto expense, Guid userId)
    {
        var existing = await context.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == id && e.UserId == userId);
        if (existing is null)
            return false;

        existing.CategoryId = expense.CategoryId;
        existing.Name = expense.Name;
        existing.Amount = expense.Amount;
        existing.Description = expense.Description;
        existing.Date = expense.Date;

        await context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DeleteExpenseAsync(Guid id, Guid userId )
    {
        var expense = await context.Expenses.FirstOrDefaultAsync(e => e.ExpenseId == id && e.UserId == userId);
        if (expense is null)
            return false;

        context.Expenses.Remove(expense);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<GetExpenseDto?> GetExpensesByIdAsync(Guid id, Guid userId)
    {
        
        var result = await context.Expenses
            .Include(e => e.Category)
            .Where(e => e.ExpenseId == id && e.UserId == userId)
            .Select(e => new GetExpenseDto
            {
                ExpenseId = e.ExpenseId,
                UserId = e.UserId,
                Name = e.Name,
                CategoryName = e.Category.CategoryName,
                Amount = e.Amount,
                Description = e.Description,
                Date = e.Date,
                CreatedAt = e.CreatedAt
            })
            .FirstOrDefaultAsync();
        return result;
    }



public async Task<List<GetExpenseDto>> GetExpensesByDateRangeAsync(Guid userId, DateOnly startDate, DateOnly endDate)
{
    var result = await context.Expenses
        .Include(e => e.Category)
        .Where(e => e.UserId == userId && e.Date >= startDate && e.Date <= endDate)
        .Select(e => new GetExpenseDto
        {
            ExpenseId = e.ExpenseId,
            UserId = e.UserId,
            Name = e.Name,
            CategoryName = e.Category.CategoryName,
            Amount = e.Amount,
            Description = e.Description,
            Date = e.Date,
            CreatedAt = e.CreatedAt
        })
        .ToListAsync();
    return result;
}

    public async Task<List<MonthlyReportDto>> GetMonthlyReportAsync(Guid userId)
    {
        var result = await context.Expenses
        .Where(e => e.UserId == userId)
        .GroupBy(e => new { e.Date.Year, e.Date.Month })
        .Select(g => new MonthlyReportDto
        {
            Year = g.Key.Year,
            Month = g.Key.Month,
            TotalAmount = g.Sum(e => e.Amount),
            TotalExpenses = g.Count()
        })
        .OrderBy(r => r.Year)
        .ThenBy(r => r.Month)
        .ToListAsync();

        return result;
    }

    public async Task<List<CategoryReportDto>> GetCategoryReportAsync(Guid userId)
    {
        var result = await context.Expenses
        .Include(e => e.Category)
        .Where(e => e.UserId == userId)
        .GroupBy(e => e.Category.CategoryName)
        .Select(g => new CategoryReportDto
        {
            CategoryName = g.Key,
            TotalAmount = g.Sum(e => e.Amount),
            TotalExpenses = g.Count()
        })
        .OrderByDescending(r => r.TotalAmount)
        .ToListAsync();
        return result;
    }
    public async Task<List<GetExpenseDto>> GetAllUsersExpensesAsync()
{    var result = await context.Expenses
        .Include(e => e.Category)
        .Select(e => new GetExpenseDto
        {
            ExpenseId = e.ExpenseId,
            UserId = e.UserId,
            Name = e.Name,
            CategoryName = e.Category.CategoryName,
            Amount = e.Amount,
            Description = e.Description,
            Date = e.Date,
            CreatedAt = e.CreatedAt
        })
        .ToListAsync();

        return result;
}
}