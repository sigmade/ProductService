using Core.Contracts;
using Core.Models;

namespace Core.UseCases.GetProduct;

public class GetProductUseCase : IGetProductUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductCoreResult> Execute(int id)
    {
        var productDataResult = await _productRepository.GetByIdAsync(id);

        var productCoreResult = productDataResult.ToResult();

        return productCoreResult;
    }
}
