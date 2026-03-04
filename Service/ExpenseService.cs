namespace ShashiControllerAPI.Service;
using ShashiControllerAPI.Models;

public class ExpenseService : IExpenseService
{
       static List<Expense> Expenses = new List<Expense>
    {
        new Expense { Id = 1, Name = "Groceries1", Amount = 150, Date = DateTime.Now.AddDays(-2), Category = "Food", Description = "Weekly grocery shopping" },
        new Expense { Id = 2, Name = "Electricity Bill", Amount = 60, Date = DateTime.Now.AddDays(-10), Category = "Utilities", Description = "Monthly electricity bill" },
        new Expense { Id = 3, Name = "Movie Tickets", Amount = 30, Date = DateTime.Now.AddDays(-5), Category = "Entertainment", Description = "Cinema outing with friends" }
    };


    public async Task<List<Expense>> GetAllExpensesAsync()
    =>await Task.FromResult(Expenses);

    

    public async Task<Expense?> GetExpensesByIdAsync(int id)
    {
        var result = Expenses.FirstOrDefault(e => e.Id == id);
        return await Task.FromResult(result);
    }
    

    public Task<List<Expense>> GetExpensesByCategoryAsync(string category)
    {
        var expensesByCategory = Expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        return Task.FromResult(expensesByCategory);
    }

    public Task<Expense> AddExpenseAsync(Expense expense)
    {
        expense.Id = Expenses.Max(e => e.Id) + 1;
        Expenses.Add(expense);
        return Task.FromResult(expense);
    }

    public Task<bool> UpdateExpenseAsync(int id, Expense expense)
    {
        var existingExpense = Expenses.FirstOrDefault(e => e.Id == id);
        if (existingExpense == null)
            return Task.FromResult(false);

        existingExpense.Name = expense.Name;
        existingExpense.Amount = expense.Amount;
        existingExpense.Date = expense.Date;
        existingExpense.Category = expense.Category;
        existingExpense.Description = expense.Description;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteExpenseAsync(int id)
    {
        var expenseToRemove = Expenses.FirstOrDefault(e => e.Id == id);
        if (expenseToRemove == null)
            return Task.FromResult(false);

        Expenses.Remove(expenseToRemove);
        return Task.FromResult(true);
    }


}   