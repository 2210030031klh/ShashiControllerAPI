using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ShashiControllerAPI.Entities;
using ShashiControllerAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ShashiControllerAPI.Service;
using Microsoft.AspNetCore.Authorization;

namespace ShashiControllerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    // public static User user =new();
    [HttpPost("register")]

    public async Task<ActionResult <User>> Register(UserDto Request)
    {
        var user=await authService.RegisterAsync(Request);
        if(user is null)
            return BadRequest("Username already exists.");
        return Ok(user);
    }



    [HttpPost("login")]
    public ActionResult<String> Login(UserDto Request)
    {
        var token=authService.LoginAsync(Request);
        if(token is null) 
            return BadRequest("Invalid username or password.");
        return Ok(token);
    }
    [Authorize]
    [HttpGet]
    public IActionResult AuthenticatedOnlyEndpoint()
    {
        return Ok("You are authenticated!");
        
    }

    //written in authservice


    // private string CreateToken(User user)
    // {
    //     // Implementation for token creation logic
    //     var claims= new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Name,user.Username)
    //     };
    //     var key = new SymmetricSecurityKey(
    //         Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

    //     var tokenDescriptor = new JwtSecurityToken(
    //         issuer: configuration.GetValue<string>("AppSettings:Issuer"),
    //         audience: configuration.GetValue<string>("AppSettings:Audience"),
    //         claims: claims,
    //         expires: DateTime.UtcNow.AddDays(1),
    //         signingCredentials: creds
    //     );
    //     return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        
    // }


}
