namespace Api.Models;

/// <summary>
/// Represents a product returned by the public API layer.
/// This is the outward-facing contract exposed to API consumers.
/// </summary>
public class ProductResponse
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
    /// Unit price of the product in dollars.
    /// </summary>
    public decimal Price { get; set; }
}
