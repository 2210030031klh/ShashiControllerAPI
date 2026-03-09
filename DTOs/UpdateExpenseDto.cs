// namespace ShashiControllerAPI.DTOs;
// public class UpdateExpenseDto
// {
//     public int Id { get; set; }
//     public required string Name {   get; set; } = string.Empty;
//     public int Amount { get; set; }=0;
//     public DateOnly Date { get; set; }
//     public required string Category { get; set; }=string.Empty;
//     public string? Description { get; set;  }
// }


namespace ShashiControllerAPI.DTOs;

public class UpdateExpenseDto
{
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public string? Description { get; set; }
    public DateOnly Date { get; set; }
}