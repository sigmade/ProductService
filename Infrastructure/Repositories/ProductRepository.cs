using Core.Contracts.ProductRepository;
using Core.Contracts.ProductRepository.Models;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<ProductDataResult> GetByIdAsync(int id)
    {
        var productSourceModel = new ProductSourceModel
        {
            Id = id,
            Name = "Sample Product",
            Price = 19.99m
        };

        var productDataResult = productSourceModel.ToDataResult();

        return productDataResult;
    }
}
