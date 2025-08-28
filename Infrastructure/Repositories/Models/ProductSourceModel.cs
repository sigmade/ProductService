namespace Infrastructure.Repositories.Models;

/// <summary>
/// Represents a product record as retrieved from the underlying data source (e.g., database or external service).
/// This model is typically used internally in the Infrastructure layer before mapping to domain or API contracts.
/// </summary>
public class ProductSourceModel
{
    /// <summary>
    /// Unique identifier of the product in the data source.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Human-readable name of the product.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Unit price of the product in dollars
    /// </summary>
    public decimal Price { get; set; }
}
