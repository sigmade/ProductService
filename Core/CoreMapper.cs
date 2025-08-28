using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core;

public static class CoreMapper
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
