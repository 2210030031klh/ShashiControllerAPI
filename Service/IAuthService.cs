using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public interface IAuthService
{
    Task<RegisterResponseDto?> RegisterAsync(UserDto request);
    Task<TokenResponseDto?> LoginAsync(UserDto request);

    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);

    
}