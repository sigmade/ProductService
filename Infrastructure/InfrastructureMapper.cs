using Core.Contracts.ProductRepository.Models;
using Infrastructure.Repositories.Models;

namespace Infrastructure;

/// <summary>
/// Provides mapping helpers for translating infrastructure/source models into repository contract models.
/// </summary>
public static class InfrastructureMapper
{
    /// <summary>
    /// Maps a <see cref="ProductSourceModel"/> retrieved from the data source to a repository-facing <see cref="ProductDataResult"/>.
    /// </summary>
    /// <param name="src">The source product record from the underlying data store.</param>
    /// <returns>A populated <see cref="ProductDataResult"/> instance.</returns>
    public static ProductDataResult ToDataResult(this ProductSourceModel src)
    {
        var result = new ProductDataResult
        {
            Id = src.Id,
            Name = src.Name,
            BasePrice = src.Price
        };

        return result;
    }
}
