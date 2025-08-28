using Core.UseCases.GetProduct.Models;

namespace Api.Models;

/// <summary>
/// Provides mapping extensions between core application models and API response contracts.
/// </summary>
public static class ApiMapper
{
    /// <summary>
    /// Maps a <see cref="ProductResult"/> (core model) to an outward facing <see cref="ProductResponse"/>.
    /// </summary>
    /// <param name="src">The source product core result.</param>
    /// <returns>A populated <see cref="ProductResponse"/> representing the same product data.</returns>
    public static ProductResponse ToResponse(this ProductResult src)
    {
        var result = new ProductResponse
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price
        };

        return result;
    }
}