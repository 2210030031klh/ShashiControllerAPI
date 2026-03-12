// namespace ShashiControllerAPI.DTOs;

// public class CategoryReportDto
// {
//     public string CategoryName { get; set; } = string.Empty;
//     public int TotalAmount { get; set; }
//     public int TotalExpenses { get; set; }
// }

namespace ShashiControllerAPI.DTOs;

public class CategoryReportDto
{
    public string CategoryName { get; set; } = string.Empty;  // e.g. Food
    public int TotalAmount { get; set; }                       // total spent in category
    public int TotalExpenses { get; set; }                     // number of expenses in category
}