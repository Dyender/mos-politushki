using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<AltTypes> AltTypes => Set<AltTypes>();

    public DbSet<UserAlts> UserAlts => Set<UserAlts>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Name)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(user => user.Name)
            .HasMaxLength(32)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(user => user.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<UserAlts>()
            .HasKey(userAlt => new
            {
                userAlt.UserId,
                userAlt.AltTypeId
            });

        modelBuilder.Entity<UserAlts>()
            .HasOne(userAlt => userAlt.User)
            .WithMany(user => user.Alts)
            .HasForeignKey(userAlt => userAlt.UserId);

        modelBuilder.Entity<UserAlts>()
            .HasOne(userAlt => userAlt.AltType)
            .WithMany()
            .HasForeignKey(userAlt => userAlt.AltTypeId);

        modelBuilder.Entity<AltTypes>()
            .HasIndex(altType => altType.Rank)
            .IsUnique();

        modelBuilder.Entity<AltTypes>()
            .Property(altType => altType.Name)
            .HasMaxLength(64)
            .IsRequired();

        modelBuilder.Entity<AltTypes>()
            .HasData(
                new AltTypes
                {
                    Id = 1,
                    Name = "Student",
                    Rank = 1,
                    BuyPrice = 0,
                    BaseIncomePerSecond = 1,
                    BaseUpgradePrice = 10
                },
                new AltTypes
                {
                    Id = 2,
                    Name = "Activist",
                    Rank = 2,
                    BuyPrice = 100,
                    BaseIncomePerSecond = 5,
                    BaseUpgradePrice = 50
                },
                new AltTypes
                {
                    Id = 3,
                    Name = "Deputy",
                    Rank = 3,
                    BuyPrice = 500,
                    BaseIncomePerSecond = 25,
                    BaseUpgradePrice = 250
                },
                new AltTypes
                {
                    Id = 4,
                    Name = "Minister",
                    Rank = 4,
                    BuyPrice = 2500,
                    BaseIncomePerSecond = 150,
                    BaseUpgradePrice = 1000
                }
            );
    }
}