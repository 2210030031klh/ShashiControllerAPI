namespace ShashiControllerAPI.DTOs;

public class MonthlyReportDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int TotalAmount { get; set; }
    public int TotalExpenses { get; set; }
}