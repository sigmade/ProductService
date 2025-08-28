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

    public static ProductDataQuery ToProductDataQuery(this ProductQuery query)
    {
        return new() { Id = query.Id };
    }

    public static DiscountDataQuery ToDiscountQuery(this ProductQuery query)
    {
        return new() { ProductId = query.Id };
    }
}
