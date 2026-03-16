namespace ShashiControllerAPI.DTOs;

public class RegisterResponseDto
{
    public Guid UserId { get; set; }
    public string? Username { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateOnly CreatedAt { get; set; }
}
