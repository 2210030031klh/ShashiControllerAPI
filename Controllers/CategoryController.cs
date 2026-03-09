using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ShashiControllerAPI.DTOs;
using ShashiControllerAPI.Service;

namespace ShashiControllerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    // GET all categories for logged in user (system + personal)
    [HttpGet]
    public async Task<ActionResult<List<GetCategoryDto>>> GetCategories()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await categoryService.GetCategoriesAsync(userId);
        return Ok(result);
    }

    // POST create personal category
    [HttpPost]
    public async Task<ActionResult<GetCategoryDto>> CreateCategory(CreateCategoryDto dto)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var result = await categoryService.CreateCategoryAsync(dto, userId);
        return Ok(result);
    }

    // DELETE personal category
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var deleted = await categoryService.DeleteCategoryAsync(id, userId);
        return deleted ? NoContent() : NotFound("Category not found or not yours.");
    }
}