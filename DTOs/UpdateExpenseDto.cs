namespace ShashiControllerAPI.DTOs;
public class UpdateExpenseDto
{
 public int Id { get; set; }
    public required string Name {   get; set; } = string.Empty;
    public int Amount { get; set; }=0;
    public DateOnly Date { get; set; }
    public required string Category { get; set; }=string.Empty;
    public string? Description { get; set;  }
}