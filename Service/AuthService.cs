using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShashiControllerAPI.Data;
using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Service;

public class AuthService(AppDbContext context,IConfiguration configuration) : IAuthService
{
    public async Task<String?> LoginAsync(UserDto request)
    {
        // Implementation for login logic
        var user = await context.Users
        .FirstOrDefaultAsync(u => u.Username == request.Username);
        if(user == null)
        {
            return null; // User not found
        }
        if(user.Username!= request.Username)
        {
            return null;
        }
        if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
        {
            return null;
        }
        
        return CreateToken(user);
    }
    public async Task<User?> RegisterAsync(UserDto request)
    {
        if(await context.Users.AnyAsync(u => u.Username == request.Username))
        {
            
            return null; // User already exists
        }
        var user=new User();
        var hashedPassword = new PasswordHasher<User>()
        .HashPassword(user, request.Password);

        user.Username = request.Username;
        user.PasswordHash = hashedPassword;
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    private string CreateToken(User user)
    {
        // Implementation for token creation logic
        var claims= new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.Username),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("AppSettings:Issuer"),
            audience: configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        
    }

}