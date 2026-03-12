using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.DTOs;

public class CreateIncomeDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public int Amount { get; set; }

    [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Source is required.")]
    [MinLength(2, ErrorMessage = "Source must be at least 2 characters.")]
    [MaxLength(100, ErrorMessage = "Source cannot exceed 100 characters.")]
    public string Source { get; set; } = string.Empty;  // e.g. Salary, Freelance

    [Required(ErrorMessage = "Date is required.")]
    public DateOnly Date { get; set; }
}