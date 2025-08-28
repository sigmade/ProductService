using Core.Contracts.DiscountClient;
using Core.Contracts.ProductRepository;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public class GetProductUseCase(
    IProductRepository productRepository, IDiscountClient discountClient) : IGetProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDiscountClient _discountClient = discountClient;

    public async Task<ProductCoreResult> Execute(int id)
    {
        var productDataResult = await _productRepository.GetByIdAsync(id);
        var productCoreResult = productDataResult.ToResult();

        var discount = await _discountClient.GetDiscountForProductAsync(id);
        if (discount > 0 && discount < 1)
        {
            productCoreResult.Price = decimal.Round(productCoreResult.Price * (1 - discount), 2);
        }

        return productCoreResult;
    }
}
