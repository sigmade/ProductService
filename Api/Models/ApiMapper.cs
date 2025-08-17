using Core.Models;

namespace Api.Models;

public static class ApiMapper
{
    public static ProductResponse ToResponse(this ProductCoreResult src)
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