using Core.Contracts.DiscountClient;
using Core.Contracts.DiscountClient.Models;

namespace Infrastructure.Clients.DiscountClient;

public class DiscountClient : IDiscountClient
{
    public Task<DiscountDataResult> GetDiscountForProduct(DiscountDataQuery query)
    {
        // demo: 10% discount for even product ids based on request.ProductId
        var discount = query.ProductId % 2 == 0 ? 0.10m : 0m;
        var result = new DiscountDataResult
        {
            DiscountValue = discount,
        };
        return Task.FromResult(result);
    }
}
