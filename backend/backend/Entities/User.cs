namespace backend.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public required string Name { get; set; }
    
    public required string PasswordHash { get; set; }
    
    public decimal Balance { get; set; }
    
    public DateTime LastIncomeAtUtc { get; set; } = DateTime.UtcNow;

    public int ClickLevel { get; set; } = 1;

    public List<UserAlts> Alts { get; set; } = [];
}