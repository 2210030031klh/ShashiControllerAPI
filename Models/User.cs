// namespace ShashiControllerAPI.Entities;
// public class User
// {
//     public Guid Id{ get; set; } 
//     public string Username { get; set; } = string.Empty;
//     public string PasswordHash { get; set; } = string.Empty;

//     public string Role { get; set; } = string.Empty;

//     public string? RefreshToken { get; set; }
//     public DateTime? RefreshTokenExpiryTime { get; set; }
// }


namespace ShashiControllerAPI.Models;

public class User
{
    public Guid UserId { get; set; }//PK

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    //Relationships 1 to M
    public List<Category> Categories { get; set; } = new();

    public List<Expense> Expenses { get; set; } = new();
    public string Role { get; set; } = "User";

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}