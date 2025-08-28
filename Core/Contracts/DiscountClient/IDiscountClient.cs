using Core.Contracts.DiscountClient.Models;

namespace Core.Contracts.DiscountClient;

public interface IDiscountClient
{
    Task<DiscountDataResult> GetDiscountForProduct(DiscountDataQuery dataQuery);
}
