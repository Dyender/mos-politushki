namespace backend.Entities;

public class AltTypes
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int Rank { get; set; }

    public decimal BuyPrice { get; set; }

    public decimal BaseIncomePerSecond { get; set; }

    public decimal BaseUpgradePrice { get; set; }
}