using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public static class GetProductMapper
{
    public static ProductCoreResult ToResult(this ProductDataResult src)
    {
        var result = new ProductCoreResult
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price
        };
        return result;
    }
}
