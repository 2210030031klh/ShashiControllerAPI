namespace ShashiControllerAPI.Service;
using Microsoft.EntityFrameworkCore;

using ShashiControllerAPI.Data;
using ShashiControllerAPI.Models;

public class ExpenseService (AppDbContext context): IExpenseService
{

    public async Task<List<Expense>> GetAllExpensesAsync()
    =>await context.Expenses.ToListAsync();


    

    public async Task<Expense?> GetExpensesByIdAsync(int id)
    {
        var result = await context.Expenses.FindAsync(id);
        return result;
    }
    

    public async Task<List<Expense>> GetExpensesByCategoryAsync(string category)
    {
        return await context.Expenses
        .Where(e => e.Category.ToLower() == category.ToLower())
        .ToListAsync();
    }

    public async Task<Expense> AddExpenseAsync(Expense expense)
    {
        // expense.Id = await context.Expenses.MaxAsync(e => e.Id) + 1;
        context.Expenses.Add(expense);
        await context.SaveChangesAsync();
        return expense;
    }

    public async Task<bool> UpdateExpenseAsync(int id, Expense expense)
    {
        var existingExpense =await  context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (existingExpense == null)
            return false;

        existingExpense.Name = expense.Name;
        existingExpense.Amount = expense.Amount;
        existingExpense.Date = expense.Date;
        existingExpense.Category = expense.Category;
        existingExpense.Description = expense.Description;
        await context.SaveChangesAsync();
        return  true;
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