namespace Core.Contracts.DiscountClient;

public interface IDiscountClient
{
    Task<decimal> GetDiscountForProductAsync(int productId);
}
