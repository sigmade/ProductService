namespace Core.Contracts.DiscountClient.Models;

/// <summary>
/// Query parameters used to request discount information for a product.
/// </summary>
public class DiscountDataQuery
{
    /// <summary>
    /// Gets or sets the unique identifier of the product to retrieve discount data for.
    /// </summary>
    /// <remarks>
    /// This value is used by the discount provider to determine if any discount applies.
    /// </remarks>
    public int ProductId { get; set; }
}
