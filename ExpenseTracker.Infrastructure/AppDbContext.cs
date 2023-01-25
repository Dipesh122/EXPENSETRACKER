using ExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().ToTable("expense");
            modelBuilder.Entity<Category>().ToTable("category")
            .HasData(
                new Category { Id = 1, Name = "Kitchen" },
                new Category { Id = 2, Name = "Glossary" },
                new Category { Id = 3, Name = "Stationery" },
                new Category { Id = 4, Name = "Others" }
            );
        }
    }
}