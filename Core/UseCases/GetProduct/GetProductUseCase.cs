using Core.Contracts.DiscountClient;
using Core.Contracts.DiscountClient.Models;
using Core.Contracts.ProductRepository;
using Core.Contracts.ProductRepository.Models;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public class GetProductUseCase(
    IProductRepository productRepository, IDiscountClient discountClient) : IGetProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDiscountClient _discountClient = discountClient;

    public async Task<ProductCoreResult> Execute(ProductCoreQuery query)
    {
        var productDataResult = await _productRepository.GetById(new ProductDataQuery { Id = query.Id });
        var productCoreResult = productDataResult.ToResult();

        var discountRequest = new DiscountDataQuery
        {
            ProductId = query.Id,
            BasePrice = productCoreResult.Price
        };
        var discountResult = await _discountClient.GetDiscountForProduct(discountRequest);
        var discount = discountResult.DiscountValue;
        if (discount > 0 && discount < 1)
        {
            productCoreResult.Price = decimal.Round(productCoreResult.Price * (1 - discount), 2);
        }

        return productCoreResult;
    }
}
