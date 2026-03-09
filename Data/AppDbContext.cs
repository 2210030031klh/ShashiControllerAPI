using Microsoft.EntityFrameworkCore;

using ShashiControllerAPI.Models;

namespace ShashiControllerAPI.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed system-wide categories (UserId = null means available to ALL users)
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Food" },
            new Category { CategoryId = 2, CategoryName = "Transport" },
            new Category { CategoryId = 3, CategoryName = "Shopping" },
            new Category { CategoryId = 4, CategoryName = "Bills" },
            new Category { CategoryId = 5, CategoryName = "Health" },
            new Category { CategoryId = 6, CategoryName = "Entertainment" },
            new Category { CategoryId = 7, CategoryName = "Other" }
        );
    }
    
    
}