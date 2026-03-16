using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public interface IAuthService
{
    Task<RegisterResponseDto?> RegisterAsync(UserDto request);
    Task<TokenResponseDto?> LoginAsync(LoginDto request);

    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);

    
}