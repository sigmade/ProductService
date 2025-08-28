using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public static class GetProductMapper
{
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
}
