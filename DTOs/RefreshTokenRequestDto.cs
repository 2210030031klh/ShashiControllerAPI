// namespace ShashiControllerAPI.DTOs;
// public class RefreshTokenRequestDto
// {
//     public Guid UserId { get; set; }
//     public required string RefreshToken { get; set; }
// }

using System.ComponentModel.DataAnnotations;

namespace ShashiControllerAPI.DTOs;

public class RefreshTokenRequestDto
{
    [Required(ErrorMessage = "UserId is required.")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Refresh token is required.")]
    public string RefreshToken { get; set; } = string.Empty;
}
