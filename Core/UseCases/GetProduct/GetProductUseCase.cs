using Core.Contracts;
using Core.Models;

namespace Core.UseCases.GetProduct;

public class GetProductUseCase(IProductRepository repository)
    : IGetProductUseCase
{
    private readonly IProductRepository _productRepository = repository;

    public async Task<Product> Execute(int id)
    {
        var product = await _productRepository.GetById(id);

        return product;
    }
}
