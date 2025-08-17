using Core.Contracts;

namespace Core.Models;

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
