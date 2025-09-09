using Core.Contracts;
using Core.Models;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public async Task<Product> GetById(int id)
    {
        var productSourceModel = new ProductSourceModel
        {
            Id = id,
            Name = "Sample Product",
            Price = 19.99m
        };

        var product = productSourceModel.ToResult();

        return await Task.FromResult(product);
    }
}
