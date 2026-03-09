namespace ShashiControllerAPI.DTOs;

public class CategoryReportDto
{
    public string CategoryName { get; set; } = string.Empty;
    public int TotalAmount { get; set; }
    public int TotalExpenses { get; set; }
}