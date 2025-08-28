namespace Core.Contracts.DiscountClient.Models;

public class DiscountDataResult
{
    public int ProductId { get; set; }
    public decimal DiscountValue { get; set; } // e.g. 0.10m means 10%
    public string? Source { get; set; }
}
