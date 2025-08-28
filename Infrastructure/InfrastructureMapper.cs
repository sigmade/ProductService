using Core.Contracts.ProductRepository.Models;
using Infrastructure.Repositories.Models;

namespace Infrastructure;

public static class InfrastructureMapper
{
    public static ProductDataResult ToDataResult(this ProductSourceModel src)
    {
        var result = new ProductDataResult
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price
        };

        return result;
    }
}
