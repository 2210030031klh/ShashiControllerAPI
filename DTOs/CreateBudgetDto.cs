using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.DTOs;

public class CreateBudgetDto
{
    [Required(ErrorMessage = "Category is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Invalid category.")]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Budget amount must be greater than 0.")]
    public int Amount { get; set; }

    [Range(1, 12, ErrorMessage = "Month must be between 1 and 12.")]
    public int Month { get; set; }

    [Range(2000, 2100, ErrorMessage = "Invalid year.")]
    public int Year { get; set; }
}