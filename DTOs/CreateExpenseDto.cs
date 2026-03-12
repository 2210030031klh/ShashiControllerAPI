// // namespace ShashiControllerAPI.DTOs;
// // public class CreateExpenseDto
// // {
// //     public int Id { get; set; }
// //     public required string Name {   get; set; } = string.Empty;
// //     public int Amount { get; set; }
// //     // public DateOnly Date { get; set; }
// //     public required string Category { get; set; }=string.Empty;
// //     // public string? Description { get; set; }
// // }

// using System.ComponentModel.DataAnnotations;

// namespace ShashiControllerAPI.DTOs;

// public class CreateExpenseDto
// {
//     // public Guid UserId { get; set; }
//     [Required]
//     [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
//     public string Name { get; set; } = string.Empty;
    
//     [Required]
//     public int CategoryId { get; set; }

//     [Required]
//     [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
//     public int Amount { get; set; }

//     [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
//     public string? Description { get; set; }
    
//     [Required]
//     public DateOnly Date { get; set; }
// }

using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.DTOs;

public class CreateExpenseDto
{
    [Required(ErrorMessage = "Expense name is required.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;    // e.g. "Lunch", "Uber"

    [Required(ErrorMessage = "Category is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid category.")]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public int Amount { get; set; }

    [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateOnly Date { get; set; }
}