using Core.Contracts.DiscountClient.Models;
using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core;

public static class CoreMapper
{
    public static ProductResult ToResult(this ProductDataResult src)
    {
        var result = new ProductResult
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price
        };

        return result;
    }

    // Mapping from API query to repository query
    public static ProductDataQuery ToProductDataQuery(this ProductQuery query)
        => new() { Id = query.Id };

    // Mapping from API query to discount service query
    public static DiscountDataQuery ToDiscountQuery(this ProductQuery query)
        => new() { ProductId = query.Id };
}
