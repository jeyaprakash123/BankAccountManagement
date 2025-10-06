using BankAccountManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankAccountManagement.Infrastructure
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankAccountManagement.Domain.Transaction> Trtansactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 101, UserName = "JP", Age = 22, Gender = "Male", Email ="abc@gmail.com" });
        }
    }
}
