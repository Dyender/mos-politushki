namespace backend.Entities;

public class UserAlts
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public int AltTypeId { get; set; }

    public AltTypes AltType { get; set; } = null!;

    public int Level { get; set; } = 1;

}