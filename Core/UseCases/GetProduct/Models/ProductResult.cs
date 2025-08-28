namespace Core.UseCases.GetProduct.Models;

/// <summary>
/// Represents the product data returned by the Get Product use case.
/// This is an application-level result (core model) that may later be mapped to API response contracts.
/// </summary>
public class ProductResult
{
    /// <summary>
    /// Unique identifier of the product.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Human-readable name of the product.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Effective unit price of the product in dollars (after any applied discounts).
    /// </summary>
    public decimal Price { get; set; }
}
