using Core.Contracts.ProductRepository;
using Core.Contracts.ProductRepository.Models;
using Infrastructure.Repositories.Models;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public Task<ProductDataResult> GetById(ProductDataQuery query)
    {
        var productSourceModel = new ProductSourceModel
        {
            Id = query.Id,
            Name = "Sample Product",
            Price = 19.99m
        };

        var productDataResult = productSourceModel.ToDataResult();

        return Task.FromResult(productDataResult);
    }
}
