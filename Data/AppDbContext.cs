using Microsoft.EntityFrameworkCore;
using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
    
}