using Core.UseCases.GetProduct.Models;

namespace Core.UseCases.GetProduct;

public interface IGetProductUseCase
{
    Task<ProductResult> Execute(ProductQuery query);
}
