namespace ShashiControllerAPI.Service;
using Microsoft.EntityFrameworkCore;

using ShashiControllerAPI.Data;
using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

public class ExpenseService (AppDbContext context): IExpenseService
{

    public async Task<List<GetExpenseDto>> GetAllExpensesAsync()
    => await context.Expenses
        .Select(e => new GetExpenseDto
        {
            Id = e.Id,
            Name = e.Name,
            Amount = e.Amount,
            Category = e.Category
        }).ToListAsync();

    public async Task<GetExpenseDto?> GetExpensesByIdAsync(int id)
    {
        var result = await context.Expenses
        .Where(e => e.Id == id)
        .Select(e => new GetExpenseDto
        {
            Id = e.Id,
            Name = e.Name,
            Amount = e.Amount,
            Category = e.Category
        })
        .FirstOrDefaultAsync();
        return result;
    }
    

    public async Task<List<GetExpenseDto>> GetExpensesByCategoryAsync(string category)
    {
        return await context.Expenses
        .Where(e => e.Category.ToLower() == category.ToLower())
        .Select(e => new GetExpenseDto
        {
            Name = e.Name,
            Amount = e.Amount,
            Category = e.Category
        })
        .ToListAsync();
    }

    public async Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto expense)
    {
        var newExpense = new Expense
        {
            Name = expense.Name,
            Amount = expense.Amount,
            Category = expense.Category
        };

        context.Expenses.Add(newExpense);
        await context.SaveChangesAsync();

        return new CreateExpenseDto
        {
            Id = newExpense.Id,
            Name = newExpense.Name,
            Amount = newExpense.Amount,
            Category = newExpense.Category
        };
    }

    public async Task<bool> UpdateExpenseAsync(int id, UpdateExpenseDto expense)
    {
        var existingExpense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (existingExpense == null)
            return false;

        existingExpense.Name = expense.Name;
        existingExpense.Amount = expense.Amount;
        existingExpense.Date = expense.Date;
        existingExpense.Category = expense.Category;
        existingExpense.Description = expense.Description;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteExpenseAsync(int id)
    {
        var expenseToRemove = await context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (expenseToRemove == null)
            return false;

        context.Expenses.Remove(expenseToRemove);
        await context.SaveChangesAsync();
        return true;
    }

}   
