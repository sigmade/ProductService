using Core.Contracts.DiscountClient;
using Core.Contracts.ProductRepository;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public class GetProductUseCase(
    IProductRepository productRepository, IDiscountClient discountClient) : IGetProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDiscountClient _discountClient = discountClient;

    public async Task<ProductResult> Execute(ProductQuery query)
    {
        var productDataQuery = query.ToProductDataQuery();
        var productDataResult = await _productRepository.GetById(productDataQuery);
        var productCoreResult = productDataResult.ToResult();
        var discountDataQuery = query.ToDiscountQuery();
        var discountDataResult = await _discountClient.GetDiscountForProduct(discountDataQuery);
        var discount = discountDataResult.DiscountValue;

        if (discount > 0 && discount < 1)
        {
            productCoreResult.Price = decimal.Round(productCoreResult.Price * (1 - discount), 2);
        }

        return productCoreResult;
    }
}
