using Core.Contracts.DiscountClient;
using Core.Contracts.ProductRepository;
using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

/// <summary>
/// Use case responsible for retrieving a single product and applying any eligible discount.
/// </summary>
/// <param name="productRepository">Repository used to retrieve raw product data.</param>
/// <param name="discountClient">Client used to query discount information for the product.</param>
/// <remarks>
/// The discount value returned by <see cref="IDiscountClient"/> is expected to be a fractional value between 0 (no discount)
/// and 1 (100% discount). If the value falls within (0,1) an adjusted price is calculated and rounded to 2 decimals.
/// Values outside that range are ignored and the base price is returned unchanged.
/// </remarks>
public class GetProductUseCase(
    IProductRepository productRepository, IDiscountClient discountClient) : IGetProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDiscountClient _discountClient = discountClient;

    /// <summary>
    /// Executes the Get Product flow for the specified <paramref name="query"/>.
    /// </summary>
    /// <param name="query">The product query containing the identifier of the product to retrieve.</param>
    /// <returns>
    /// A <see cref="ProductResult"/> representing the product with an effective price after applying
    /// any valid discount. If no valid discount exists the original base price is returned.
    /// </returns>
    /// <remarks>
    /// The resulting price is rounded to 2 decimal places when a discount is applied.
    /// </remarks>
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
