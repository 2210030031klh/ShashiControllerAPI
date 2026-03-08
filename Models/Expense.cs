namespace ShashiControllerAPI.Models;
public class Expense
{
    public int Id { get; set; }
    public required string Name {   get; set; }
    public int Amount { get; set; }
    public DateOnly Date { get; set; }
    public required string Category { get; set; }
    public string? Description { get; set; }
    

}