namespace Core.Contracts.DiscountClient.Models;

public class DiscountDataQuery
{
    public int ProductId { get; set; }
    public decimal BasePrice { get; set; }
    public string? CustomerId { get; set; }
}
