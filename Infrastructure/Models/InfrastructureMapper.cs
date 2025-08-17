using Core.Contracts;

namespace Infrastructure.Models;

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
