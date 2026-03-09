// namespace ShashiControllerAPI.Models;
// public class Expense
// {
//     public int Id { get; set; }
//     public required string Name {   get; set; }
//     public int Amount { get; set; }
//     public DateOnly Date { get; set; }
//     public required string Category { get; set; }
//     public string? Description { get; set; }
    

// }
namespace ShashiControllerAPI.Models;

public class Expense
{
    public Guid ExpenseId { get; set; }//PK

    public Guid UserId { get; set; }//FK

    public int CategoryId { get; set; }//FK

    public int Amount { get; set; }

    public string? Description { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
//Navigation properties
    public User User { get; set; } = null!;

    public Category Category { get; set; } = null!;
}