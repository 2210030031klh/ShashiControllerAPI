namespace ShashiControllerAPI.DTOs;

public class GetCategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public bool IsPersonal { get; set; }  // true if personal, false if system
}