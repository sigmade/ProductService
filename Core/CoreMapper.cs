using Core.Contracts.DiscountClient.Models;
using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core;

/// <summary>
/// Provides mapping extension methods for translating between data layer / contract models and core application models.
/// </summary>
public static class CoreMapper
{
    /// <summary>
    /// Maps a <see cref="ProductDataResult"/> (repository data model) to a <see cref="ProductResult"/> (core model).
    /// </summary>
    /// <param name="src">The source product data result returned from the repository.</param>
    /// <returns>A new <see cref="ProductResult"/> with values copied from <paramref name="src"/>.</returns>
    public static ProductResult ToResult(this ProductDataResult src)
    {
        var result = new ProductResult
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.BasePrice
        };

        return result;
    }

    /// <summary>
    /// Creates a <see cref="ProductDataQuery"/> suitable for repository access from a core <see cref="ProductQuery"/>.
    /// </summary>
    /// <param name="query">The core product query.</param>
    /// <returns>A repository-level query object.</returns>
    public static ProductDataQuery ToProductDataQuery(this ProductQuery query)
    {
        return new() { Id = query.Id };
    }

    /// <summary>
    /// Creates a <see cref="DiscountDataQuery"/> used to request discount information for the product in <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The core product query.</param>
    /// <returns>A discount data query referencing the product identifier.</returns>
    public static DiscountDataQuery ToDiscountQuery(this ProductQuery query)
    {
        return new() { ProductId = query.Id };
    }
}
