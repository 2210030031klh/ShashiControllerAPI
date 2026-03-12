using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.Models;

public class Category
{
    public int CategoryId { get; set; }                  // PK

    [MaxLength(50)]                                       // VARCHAR(50) in MySQL
    public required string CategoryName { get; set; }    // e.g. Food, Transport, Gym

    public Guid? UserId { get; set; }                    // FK → Users.UserId
                                                         // NULL = system category (all users)
                                                         // GUID = personal category (one user)
    // Relationships:
    // Category (1) → Expenses (Many)
    // Category (1) → Budgets (Many)
}