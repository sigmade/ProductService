using Core.Models;

namespace Infrastructure.Models;

public static class InfrastructureMapper
{
    public static Product ToResult(this ProductSourceModel src)
    {
        var result = new Product
        {
            Id = src.Id,
            Name = src.Name,
            Price = src.Price
        };

        return result;
    }
}
