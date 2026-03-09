// namespace ShashiControllerAPI.Models;
// public class GetExpenseDto
// {
//     public int Id { get; set; }
//     public required string Name {   get; set; }
//     public int Amount { get; set; }
    
//     // public DateOnly Date { get; set; }
//     public required string Category { get; set; }

//     // public string? Description { get; set; }
    

// }


namespace ShashiControllerAPI.DTOs;

public class GetExpenseDto
{
    public Guid ExpenseId { get; set; }
    public Guid UserId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public int Amount { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly CreatedAt { get; set; }
}