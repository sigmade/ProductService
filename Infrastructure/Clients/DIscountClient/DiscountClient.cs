using Core.Contracts.DiscountClient;
using Core.Contracts.DiscountClient.Models;

namespace Infrastructure.Clients.DiscountClient;

/// <summary>
/// Demo implementation of <see cref="IDiscountClient"/> used for development/testing.
/// </summary>
/// <remarks>
/// This stub applies a fixed 10% discount for even product IDs and 0% for odd IDs.
/// Replace with a real HTTP / service client when integrating an external discount provider.
/// </remarks>
public class DiscountClient : IDiscountClient
{
    /// <summary>
    /// Retrieves discount information for the specified product (demo logic).
    /// </summary>
    /// <param name="query">The discount query containing the target <see cref="DiscountDataQuery.ProductId"/>.</param>
    /// <returns>A <see cref="DiscountDataResult"/> whose <see cref="DiscountDataResult.DiscountValue"/> is 0.10 for even IDs, otherwise 0.</returns>
    public Task<DiscountDataResult> GetDiscountForProduct(DiscountDataQuery query)
    {
        // Demo: 10% discount for even product ids
        var discount = query.ProductId % 2 == 0 ? 0.10m : 0m;
        var result = new DiscountDataResult
        {
            DiscountValue = discount,
        };
        return Task.FromResult(result);
    }
}
