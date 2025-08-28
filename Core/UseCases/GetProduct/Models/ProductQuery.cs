namespace Core.UseCases.GetProduct.Models;

/// <summary>
/// Query object representing the request to retrieve a single product.
/// </summary>
public class ProductQuery
{
    /// <summary>
    /// Unique identifier of the product to retrieve.
    /// </summary>
    public int Id { get; set; }
}
