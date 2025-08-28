using Core.Contracts.DiscountClient;

namespace Infrastructure.Clients.DIscountClient;

public class DiscountClient : IDiscountClient
{
    public Task<decimal> GetDiscountForProductAsync(int productId)
    {
        // demo: 10% discount for even product ids
        var discount = productId % 2 == 0 ? 0.10m : 0m;
        return Task.FromResult(discount);
    }
}
