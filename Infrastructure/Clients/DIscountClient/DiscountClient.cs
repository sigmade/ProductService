using Core.Contracts.DiscountClient;
using Core.Contracts.DiscountClient.Models;

namespace Infrastructure.Clients.DIscountClient;

public class DiscountClient : IDiscountClient
{
    public Task<DiscountDataResult> GetDiscountForProduct(DiscountDataQuery query)
    {
        // demo: 10% discount for even product ids based on request.ProductId
        var discount = query.ProductId % 2 == 0 ? 0.10m : 0m;
        var result = new DiscountDataResult
        {
            ProductId = query.ProductId,
            DiscountValue = discount,
            Source = "DemoRule"
        };
        return Task.FromResult(result);
    }
}
