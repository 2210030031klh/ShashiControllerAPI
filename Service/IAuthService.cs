using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Entities;

namespace ShashiControllerAPI.Service;

public interface IAuthService
{
    Task<User?> RegisterAsync(UserDto request);
    Task<string?> LoginAsync(UserDto request);
}