// namespace ShashiControllerAPI.DTOs;

// public class MonthlyReportDto
// {
//     public int Year { get; set; }
//     public int Month { get; set; }
//     public int TotalAmount { get; set; }
//     public int TotalExpenses { get; set; }
// }

namespace ShashiControllerAPI.DTOs;

public class MonthlyReportDto
{
    public int Year { get; set; }           // e.g. 2026
    public int Month { get; set; }          // 1-12
    public int TotalAmount { get; set; }    // total spent that month
    public int TotalExpenses { get; set; }  // number of expenses that month
}