namespace ShashiControllerAPI.DTOs;

public class BudgetReportDto
{
    public string CategoryName { get; set; } = string.Empty;  // category name
    public int BudgetAmount { get; set; }                      // how much budgeted
    public int SpentAmount { get; set; }                       // how much spent
    public int RemainingAmount { get; set; }                   // budget - spent
    public double Percentage { get; set; }                     // spent/budget × 100
    public bool IsOverBudget { get; set; }                     // spent > budget
}