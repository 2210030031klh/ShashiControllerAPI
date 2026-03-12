//   namespace ShashiControllerAPI.DTOs;
// public class UserDto
// {
//     public required string Username { get; set; } = string.Empty;
//     public required string Password { get; set; } = string.Empty;
//     public string Email { get; set; } = string.Empty;
//     public string Role { get; set; } = "User"; 
// }\

using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.DTOs;

public class UserDto
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
    [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public required string Email { get; set; }

    [MaxLength(20, ErrorMessage = "Role cannot exceed 20 characters.")]
    public string Role { get; set; } = "User"; // "User" or "Accountant"
}
