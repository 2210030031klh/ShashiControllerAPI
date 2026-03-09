namespace ShashiControllerAPI.Models;

public class Category
{
    public int CategoryId { get; set; }//PK

    public required string CategoryName { get; set; }

    public Guid? UserId { get; set; }//FK

    public User? User { get; set; }//Nvigation property
// Relationships 1 to M
    public List<Expense> Expenses { get; set; } = new();
}