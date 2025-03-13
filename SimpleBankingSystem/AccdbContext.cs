using Microsoft.EntityFrameworkCore;

namespace SimpleBankingSystem
{
    public class AccdbContext : DbContext
    {

        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Bhavitha;Database=SimpleBankingSystem;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .HasIndex(e => e.AccountNumber)
                .IsUnique();
            modelBuilder.Entity<AccountEntity>()
                .Property(e => e.Balance)
                .HasDefaultValue(0.00);
        }
    }
}


