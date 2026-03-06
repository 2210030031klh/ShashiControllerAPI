namespace ShashiControllerAPI.DTOs;
public class CreateExpenseDto
{
    public int Id { get; set; }
    public required string Name {   get; set; } = string.Empty;
    public int Amount { get; set; }
    // public DateOnly Date { get; set; }
    public required string Category { get; set; }=string.Empty;
    // public string? Description { get; set; }
}